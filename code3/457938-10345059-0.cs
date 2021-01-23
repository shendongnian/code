    using System;
    namespace wildert
    {
        public class Metronome
        {
            public event TickHandler Tick;
            public EventArgs e = null;
            public delegate void TickHandler(Metronome m, EventArgs e);
            public void Start()
            {
               // while (true) //uncomment this line if you want event to fire repeatedly
                {
                    System.Threading.Thread.Sleep(3000);
                    if (Tick != null)
                    {
                        Tick(this, e);
                    }
                }
            }
        }
            public class Listener
            {
                public void Subscribe(Metronome m)
                {
                    m.Tick += new Metronome.TickHandler(HeardIt);
                }
                private void HeardIt(Metronome m, EventArgs e)
                {
                    System.Console.WriteLine("HEARD IT");
                }
    
            }
        class Test
        {
            static void Main()
            {
                Metronome m = new Metronome();
                Listener l = new Listener();
                l.Subscribe(m);
                m.Start();
            }
        }
    }
