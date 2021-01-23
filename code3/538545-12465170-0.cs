    namespace @event
    {
        class Program
        {
            static void Main(string[] args)
            {
                Tick tijd = new Tick();
                tijd.interval = 10;
                tijd.TijdVeranderd += new EventHandler(Uitvoeren);
    
                for (int i = 0; i < 100; i++)
                {
                    tijd.Plus(1);
                }
    
                Console.ReadLine();
            }
    
            static void Uitvoeren(object sender, EventArgs e)
            {
                Console.WriteLine("Uitgevoerd!");
            }
        }
    
        public class Tick
        {
            public event EventHandler TijdVeranderd;
    
            public int interval;
    
            private int tijd;
    
            public void Plus(int i)
            {
                Verander += 1;
            }
    
            public int Verander
            {
                get { return this.tijd; }
                set
                {
                    this.tijd = value;
    
                    if (tijd == interval)
                    {
                        if (this.TijdVeranderd != null)
                            this.TijdVeranderd(this, new EventArgs());
    
                        tijd = 0;
                    }
                }
            }
    
            public Tick() { }
        }
    }
