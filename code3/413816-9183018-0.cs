    public class RSSCalendarDay
    {
        private RSSCalendarRuleDay? dayOrder;
        public RSSCalendarRuleDay? DayOrder
        {
            get { return this.dayOrder; }
            set { this.dayOrder = value; }
        }
        public int DayOrderInt
        {
            get { return this.dayOrder.HasValue ? (int)this.dayOrder.Value : 0; }
            set { this.dayOrder = value != 0 ? (RSSCalendarRuleDay?)value : null; }
        }
    }
