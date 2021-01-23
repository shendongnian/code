    using System.Threading;
    using System;
    namespace ConsoleApplication1 {
        public class Example {
            private static readonly EventWaitHandle Ewh = new EventWaitHandle(true, EventResetMode.ManualReset);
            private static readonly EventWaitHandle Btn = new EventWaitHandle(true, EventResetMode.AutoReset);
    
            [STAThread]
            public static void Main() {
                for(int i = 0; i <= 0x4; i++) {
                    var t = new Thread(ThreadProc);
                    t.Start(i);
                }
                Ewh.Reset();
                Console.ReadLine();
                Console.WriteLine("Press ENTER to release a waiting thread.");
                Ewh.Set();
            }
    
            private static void _button_Click(object sender, EventArgs e) {
                Console.WriteLine(new Random().Next(0x1388));
                Thread.Sleep(10);
            }
        
            public static void ThreadProc(object data) {
                Btn.WaitOne();
                Console.WriteLine("Thread {0} blocks.", data);
                _button_Click(null, EventArgs.Empty);
                Btn.Set();
                Ewh.WaitOne();
                Console.WriteLine("Thread {0} exits.", data);
            }
        }
    }
