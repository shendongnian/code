    public static void Printing(string printer, string fileLoc)
            {
                //Set Duplex Settings Session
                PrinterSettings set = new PrinterSettings();
                set.PrinterName = printer;
                set.Duplex = Duplex.Default;
                
                //Start Printing process
                ProcessStartInfo info = new ProcessStartInfo();
                info.Verb = "print";
                info.FileName = fileLoc;
                //Print and close program immediatly
                info.CreateNoWindow = true;
                info.WindowStyle = ProcessWindowStyle.Hidden;
    
                Process P = new Process();
                P.StartInfo = info;
                P.Start();
    
                P.WaitForInputIdle();
                System.Threading.Thread.Sleep(3000);
                set.Duplex = Duplex.Simplex; //It seems setting back printer to normal wasn't thoroughly tested though 
                if (false == P.CloseMainWindow())
                    P.Kill();
                //kill process
            }
