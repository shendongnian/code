    public class EmployeeMini
    {
        // ...
        private List<HolidayCalendar> _Holidays = new List<HolidayCalendar>();
        // ...
    }
    
    public class CorporateTeamTimeSheetTotalsForSpecifiedTimeFrame
    {
        private List<EmployeeMini> _EmployeesList = new List<EmployeeMini>();
    
        public List<EmployeeMini> EmployeeList
        {
            get { return _EmployeesList; }
            set { _EmployeesList = value; }
        }
    }
