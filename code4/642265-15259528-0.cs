    public partial class DateConstraint
    {
        public virtual bool Matches()
        {
            return (DateTime.Now.Hour > this.StartTime.Hours) && (DateTime.Now.Minute > this.StartTime.Minutes) && (DateTime.Now.Hour < this.EndTime.Hours) && (DateTime.Now.Minute < this.EndTime.Minutes);
        }
    }
    public partial class DayOfWeekConstraint : DateConstraint
    {
        public override bool Matches()
        {
            return base.Matches() && this.DayOfWeek == Convert.ToInt16(DateTime.Now.DayOfWeek);
        }
    }
    public partial class DayOfYearConstraint : DateConstraint
    {
        public override bool Matches()
        {
            return base.Matches() && Date.Day == DateTime.Now.Day && Date.Month == DateTime.Now.Month;
        }
    }
    public partial class AbsoluteDateConstraint : DateConstraint
    {
        public override bool Matches()
        {
            
            return base.Matches() && Date.Day == DateTime.Now.Day && Date.Month == DateTime.Now.Month && Date.Year == DateTime.Now.Year;
        }
    }
