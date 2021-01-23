    class WeapsCollection
    {
        public Dictionary<string, WeaponDetails> Weapons { get; set; }
    }
    class WeaponList
    {
        public WeaponDetails AEK { get; set; }
        public WeaponDetails XM8 { get; set; }
    }
    class WeaponDetails
    {
        public string Name { get; set; }
        public int Kills { get; set; }
        public int Shots_Fired { get; set; }
        public int Shots_Hit { get; set; }
    }
    class Program  
    {
        static void Main(string[] args)
        {
            string json = @"
            {
               'weapons':
                    
                        {
                           'aek':
                                {
                                   'name':'AEK-971 Vintovka',
                                   'kills':47,
                                   'shots_fired':5406,
                                   'shots_hit':858
                                },
                           'xm8':
                                {
                                   'name':'XM8 Prototype',
                                   'kills':133,
                                   'shots_fired':10170,
                                   'shots_hit':1790
                                },
                        }
                   
            }";
            WeapsCollection weps = JsonConvert.DeserializeObject<WeapsCollection>(json);
            Console.WriteLine(weps.Weapons.First().Value.Shots_Fired);            
           
            Console.ReadLine();
           
        }
    }
