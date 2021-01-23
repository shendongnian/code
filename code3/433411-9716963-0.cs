        #region "Leg Class that implements IComparable interface [C#]"
        public class Leg:IComparable<Leg>
        {
            public int Day { get; set; }
            public int Hour { get; set; }
            public int Min { get; set; }
    
            public int CompareTo(Leg leg)
            {
                if (this.Day == leg.Day)
                {
                    if (this.Hour == leg.Hour)
                    {
                        return this.Min.CompareTo(leg.Min);
                    }
                }
                return this.Day.CompareTo(leg.Day);
            }
        }
        #endregion
       //Main code
       List<Leg> legs = GetLegs();
       legs.Sort();
