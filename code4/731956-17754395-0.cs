    static void Main(string[] args)
    {
               
        string appGuid = ((GuidAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(GuidAttribute), false).GetValue(0)).Value.ToString();
    
        // unique id for global mutex - Global prefix means it is global to the machine
        string mutexId = string.Format("Global\\{{{0}}}", appGuid);
    
        using (var mutex = new Mutex(false, mutexId))
        {
    
            var hasHandle = false;
            try
            {
                try
                {
                    hasHandle = mutex.WaitOne(5000, false);
                }
                catch (AbandonedMutexException)
                {
                    hasHandle = true;
                }
    
                        
                if (hasHandle)
                {
                    // main app
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Form1 frm = new Form1();
    
                    HandleArgs(args,frm); // handle first start with args
    
                    Server(appGuid, frm); // handle next clients
     
                    Application.Run(frm);
                }
                else
                {
                    //any next client..
                    var cli = new NamedPipeClientStream(appGuid);
                    // connect to first app
                    cli.Connect();
                    // serialiaze args and send over
                    var bf = new BinaryFormatter();
                    bf.Serialize(cli, args);  // the commandline args over the line
                    cli.Flush();
                    cli.Close();
                    // done
                }
            }
            finally
            {
                if (hasHandle)
                    mutex.ReleaseMutex();
            }
        }
    }
    
    // do usefull stuff with the commandline args
    static void HandleArgs(string[] args, Form1 frm)
    {
        foreach (var s in args)
        {
            // just append the args to the textbox
            frm.textBox1.Text += s;
            frm.textBox1.Text += Environment.NewLine;
        }
    }
    
    // server that runs async
    static void Server(string appGuid, Form1 frm)
    {
        var srv = new NamedPipeServerStream(appGuid, PipeDirection.InOut, 5, PipeTransmissionMode.Byte, PipeOptions.Asynchronous);
    
        srv.BeginWaitForConnection(state =>
        {
            NamedPipeServerStream nps = (NamedPipeServerStream)state.AsyncState;
            nps.EndWaitForConnection(state);
                    
            var bf = new BinaryFormatter();
            string[] args = (string[])bf.Deserialize(nps);
    
            // don't forget to call on the UI thread
            frm.Invoke(new MethodInvoker(() => { HandleArgs(args, frm); }));
    
            nps.Disconnect();
                   
            Server(appGuid, frm); // restart server
        }, srv);
    }
