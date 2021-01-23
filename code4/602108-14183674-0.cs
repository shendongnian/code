    public class Measurement
            {
                public DateTime t;
                public double kwh;
    
                public Measurement(string t, double kwh)
                {
                    this.t = DateTime.Parse(t);
                    this.kwh = kwh;
                }
            }
    
            public static double getPowerConsumption(IEnumerable<Measurement> measurements, DateTime day)
            {
                DateTime never = DateTime.MinValue;
                DateTime tomorrow = day.AddDays(1);
                DateTime prev = never;
                double kwh = 0;
    
                foreach (Measurement m in measurements)
                {
                    if (m.t >= day)
                    //  measurement in our after or day
                    {
                        if (m.t >= tomorrow)
                        {
                            if ((prev != never) && (prev < m.t))
                            {
                                //  add portion up to midnight
                                kwh += m.kwh * (tomorrow.Ticks - prev.Ticks) / (double)(m.t.Ticks - prev.Ticks);
                            }
                            break;
                        }
                        else if ((prev != never) && (prev < day) && (prev < m.t))
                        {
                            kwh += m.kwh * (m.t.Ticks - day.Ticks) / (double)(m.t.Ticks - prev.Ticks);
                        }
                        else
                        {
                            kwh += m.kwh;
                        }
                    }
                    prev = m.t;
                }
    
                return kwh;
            }
    
            static void Main(string[] args)
            {
                DateTime myDay = new DateTime(2012, 11, 2);
                List<Measurement> measurements = new List<Measurement>() { new Measurement("01.11.2012 23:30", 10), 
                                                                           new Measurement("02.11.2012 10:00", 1), 
                                                                           new Measurement("02.11.2012 23:30", 5), 
                                                                           new Measurement("03.11.2012 10:00", 6) };
                double kwh = getPowerConsumption(measurements, myDay);
    
                Console.WriteLine("Powerconsumption for " + myDay.ToShortDateString() + " was " + kwh.ToString("#.##") + "kWh");
            }
