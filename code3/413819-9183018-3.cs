    public class RSSCalendarDay
    {
        private RSSCalendarRuleDay dayOrder;
        public RSSCalendarRuleDay DayOrder
        {
            get { return this.dayOrder; }
            set { this.dayOrder = value; }
        }
        public int DayOrderInt
        {
            get 
            { 
                return (int)this.dayOrder;
            }
            set
            {
                if (!Enum.IsDefined(typeof(RSSCalendarRuleDay), value))
                    throw new ArgumentException("Invalid day value specified (out of day range of 1 to 7).");
                this.dayOrder = (RSSCalendarRuleDay)value; 
            }
        }
    }
