        namespace Thread_TerminateProblem
        {    
            public partial class Form1 : Form
            {     
           
            private static AutoResetEvent m_ResetEvent = null;                
            private static ManualResetEvent m_ResetEvent_Thread = new ManualResetEvent(false);
            enum ServiceState { Start, Stop };
            bool flag = false;
            int x = 0;
            ServiceState _state;
            public Form1()
            {
                InitializeComponent();
            }
            private void btnStart_Click(object sender, EventArgs e)
            {
                flag = true;
                _state = ServiceState.Start;
                m_ResetEvent = new AutoResetEvent(true);            
                Thread t1 = new Thread(fun_Thread1);
                t1.Start();
                t1.Name = "Thread1";            
            }
            private void btnStop_Click(object sender, EventArgs e)
            {
                _state = ServiceState.Stop;
                m_ResetEvent.Set();           
            }
        
            private void fun_Thread1()
            {
                while (true)
                {                               
                    m_ResetEvent.WaitOne();                
                    switch (_state)
                    {
                        case ServiceState.Start:
                            {                            
                                Thread t = new Thread(fun_Thread2);
                                t.Start();
                                t.Name = "Thread2";
                                break;
                            }
                        case ServiceState.Stop:
                            {
                                m_ResetEvent_Thread.Set();
                                flag = true;
                                break;
                            }
                    }
                    // When the child Thread terminates, Then only this thread should terminate
                    if (flag == true)
                    {
                        // Waiting for notification from child Thread
                        notifyParent.WaitOne();
                        Thread.Sleep(100);
                        break;
                    }                
                    m_ResetEvent.Reset();                              
                }            
            }
                       
            private static ManualResetEvent notifyParent = new ManualResetEvent(false);
            private void fun_Thread2()
            {
                while (true)
                {
                    if (m_ResetEvent_Thread.WaitOne(1, false))
                    {
                        notifyParent.Set();
                        break;
                    }
                    x++;                
                }
            }     
        }
    }
