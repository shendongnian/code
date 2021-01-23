    using System;
    using System.Threading;
    using System.Windows.Forms;
    
    namespace ConsoleApplication1
    {
        public class Example
        {
            private static Button _button;
            private static readonly EventWaitHandle Ewh = new EventWaitHandle(true, EventResetMode.ManualReset);
            private static readonly EventWaitHandle Btn = new EventWaitHandle(true, EventResetMode.AutoReset);
            [STAThread]
            public static void Main()
            {
                Ewh.Reset();
                _button = new Button();
                _button.Click += _button_Click;
                for (int i = 0; i <= 0x4; i++)
                    new Thread(ThreadProc).Start(i);
                Console.WriteLine("Press ENTER to release a waiting thread.");
                Console.ReadLine();
                Ewh.Set();
                Console.ReadLine();
            }
    
            private static void _button_Click(object sender, EventArgs e)
            {
                Console.WriteLine(new Random().Next(0x1388));
                Thread.Sleep(10);
            }
    
            public static void ThreadProc(object data)
            {
                Btn.WaitOne();
                Console.WriteLine("Thread {0} blocks.", data);
                _button.PerformClick();
                Btn.Set();
                Ewh.WaitOne();
                Console.WriteLine("Thread {0} exits.", data);
            }
        }
    }
