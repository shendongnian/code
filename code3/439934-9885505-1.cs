     public class Metronome
        {
            public event TickHandler Tick;
            public EventArgs e = null;
            public delegate void TickHandler(Metronome m, EventArgs e);
            public void Start()
            {
                while (true)
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
