            class Calender
            {
                public DateTime datetime { get; set;}
            }
    
            class DateComparer : Calender, IComparable<Calender>
            {
                public int CompareTo(Calender other)
                {
                    return other.datetime.Date.CompareTo(this.datetime.Date);
                }
            }
