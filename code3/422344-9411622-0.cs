        [Flags, Serializable,]
        public enum WeekDays
        {
            Sunday = 1,
            Monday = 2,
            Tuesday = 4,
            Wednesday = 8,
            Thursday = 16,
            Friday = 32,
            Saturday = 64,
            WeekendDays = Sunday | Saturday,
            WorkDays = Monday | Tuesday | Wednesday | Thursday | Friday,
            EveryDay = WeekendDays | WorkDays
        }
        public static WeekDays Days { get; set; }
        private static void Main(string[] args)
        {
            WeekDays today = WeekDays.Sunday;
            Days = WeekDays.WorkDays;
            if ((Days & today) == today)
            {
                Console.WriteLine("Today is included in Days");
            }
            Console.ReadKey();
        }
