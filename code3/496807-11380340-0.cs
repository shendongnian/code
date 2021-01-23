    namespace CarRace
    {
    class Cars
    {
        public string Name { get; set; }
        public int StartPOS { get; set; }
        public int CurPOS { get; set; }
        public int Speed { get; set; }
        public double Location { get; set; }
        public string Make { get; set; }
        private static List<Cars> CarList;
        private static string ProgPart;
        public Cars(string Name, int StartPOS, int CurPOS, int Speed, double Location, string Make)
        {
            this.Name = Name;
            this.StartPOS = StartPOS;
            this.CurPOS = CurPOS;
            this.Speed = Speed;
            this.Location = Location;
            this.Make = Make;
        }
        public static List<Cars> FillList()
        {
            return CarList;
        }
        public static void Main()
        {
            try
            {
                bool Prog = false;
                //Get Part to display
                while (!Prog)
                {
                    Console.WriteLine("Select the part you would like to test.(1 or 2)");
                    ProgPart = Console.ReadLine();
                    if (ProgPart == "1" || ProgPart == "2")
                    {
                        Prog = true;
                    }
                }
                Console.WriteLine("----------------------------------------");
                //Read XML File and set the CarList
                if (File.Exists("NewRace.xml"))
                {
                    XDocument doc = XDocument.Load("NewRace.xml");
                    var nCars = doc.Descendants("Car").Select(x => new Cars("", 0, 0, 0, 0, "")
                    {
                        Name = x.Attribute("Name").Value,
                        StartPOS = int.Parse(x.Element("StartPOS").Value),
                        CurPOS = 0,
                        Speed = int.Parse(x.Element("Speed").Value),
                        Location = double.Parse(x.Element("Location").Value),
                        Make = x.Attribute("Make").Value
                    });
                    CarList = new List<Cars>();
                    foreach (var car1 in nCars)
                    {
                        if (ProgPart == "1")
                        {
                            CarList.Add(new Cars(car1.Name, car1.StartPOS, car1.CurPOS, car1.Speed, car1.Location, car1.Make));
                        }
                        else
                        {
                            CarList.Add(new Cars(car1.Name, car1.StartPOS, car1.CurPOS, 0, car1.Location, car1.Make));
                        }
                    }
                }
                else
                {
                    Console.WriteLine("File Not Found!");
                    Console.ReadKey();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static int CompareCurrentLocation(Cars c1, Cars c2)
        {
            return c2.Location.CompareTo(c1.Location);
        }
        public static Boolean UpdateLeaderBoard(long i)
        {
            try
            {
                int p = 1;
                int prevPOS = 1;
                DateTime? PrevTime;
                double dist = 0;
                double prevLocation = 0;
                if (i == 0)
                {
                    return false;
                }
                foreach (var car in CarList)
                {
                    if (ProgPart == "2")
                    {
                        switch (car.Make)
                        {
                            case "300ZX":
                                //Slow continuous gain of speed by percentage after 60 with top speed of 320.
                                if (i <= 15)
                                {
                                    car.Speed = car.Speed + (60 / 10);
                                }
                                else if (car.Speed < 320)
                                {
                                    double percent = (double)(car.Speed * .1);
                                    if ((Convert.ToInt32(car.Speed + percent)) > 320)
                                    {
                                        car.Speed = 320;
                                    }
                                    else
                                    {
                                        car.Speed = Convert.ToInt32(car.Speed + (percent));
                                    }
                                }
                                break;
                            case "Camero":
                                //0-60 4 seconds 60-220 20 seconds Top 220
                                if (i <= 4)
                                {
                                    car.Speed = car.Speed + (60 / 4);
                                }
                                else if (i <= 20)
                                {
                                    car.Speed = car.Speed + 10;
                                }
                                break;
                            case "Mustang":
                                //0-top(210) 25 seconds
                                if (car.Speed <= 200)
                                {
                                    car.Speed = car.Speed + (200 / 20);
                                }
                                break;
                            case "VW Bug":
                                //Constant Speed
                                car.Speed = 165;
                                break;
                            default:
                                Console.WriteLine("Make not found");
                                break;
                        }
                    }
                    //Set Cars Current Location
                    dist = (((car.Speed * 1609.344) * 1) / 1609.344) / 3600;
                    car.Location = car.Location + dist;
                }
                //Sort list by location
                Comparison<Cars> compLoc = Cars.CompareCurrentLocation;
                CarList.Sort(compLoc);
                PrevTime = DateTime.Now;
                //Set the Current Position
                foreach (var car in CarList)
                {
                    if (car.Location != prevLocation)
                    {
                        car.CurPOS = p;
                    }
                    else
                    {
                        car.CurPOS = prevPOS;
                    }
                    prevPOS = car.CurPOS;
                    prevLocation = car.Location;
                    p++;
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
