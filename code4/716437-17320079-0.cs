    using System;
    using System.Timers;
    
    namespace Example
    {
        public class Program
        {
            private Timer m_timer;
            private event EventHandler<EventArgs<string>> ReadingAvailable;
    
            protected virtual void OnReadingAvailable(string value)
            {
                EventHandler<EventArgs<string>> handler = ReadingAvailable;
                if (handler != null)
                {
                    handler(this, new EventArgs<string>(value));
                }
            }
    
            public static void Main(string[] args)
            {
                var foo = new Program();
                foo.Initialise();
    
                Console.ReadLine();
            }
    
            private void Initialise()
            {
                ReadingAvailable += Program_ReadingAvailable;
    
                m_timer = new Timer {Interval = 1000};
                m_timer.Elapsed +=timer_Elapsed;
                m_timer.Enabled = true;
                m_timer.Start();
    
            }
    
            private void timer_Elapsed(object sender, ElapsedEventArgs e)
            {
                 string readData;
                 UInt32 numBytesRead = 0;
                 // Note that the Read method is overloaded, so can read string or byte array data
                 ftStatus = myFtdiDevice.Read(out readData, numBytesAvailable, ref numBytesRead);
                // add the condition checking here to validate that the readData in not empty.
                OnReadingAvailable(readData);
            }
    
            private void Program_ReadingAvailable(object sender, EventArgs<string> e)
            {
                string readData= e.Value;
                Console.WriteLine(readData);
            }
        }
    
        ///
        /// Helper class to parse argument in the EventArg
        public class EventArgs<T> : EventArgs
        {
            private readonly T m_value;
    
            protected EventArgs()
                : base()
            {
                m_value = default(T);
            }
    
            public EventArgs(T value)
            {
                m_value = value;
            }
    
            public T Value
            {
                get { return m_value; }
            }
        }
    }
