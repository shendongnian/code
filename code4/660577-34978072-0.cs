	[DebuggerDisplay("ID: {ID}, Name: {Name}")]
	public class Employee
	{
		public Employee(string name)
		{
			Name = name;
			Schedules = new List<Schedule>();
		}
		public string Name { get; set; }
		public List<Schedule> Schedules { get; set; }
	}
	public class EmployeeSchedule
	{
		public EmployeeSchedule(Employee employee, Schedule schedule)
		{
			Employee = employee;
			Schedule = schedule;
		}
		public Employee Employee { get; set; }
		public Schedule Schedule { get; set; }
	}
	[DebuggerDisplay("ID: {ID}, Name: {Name}")]
	public class Schedule
	{
		public Schedule(string name)
		{
			Name = name;
		}
		public string Name { get; set; }
	}
	[DebuggerDisplay("Name: {Name}, Start: {DateStart}, End: {DateEnd}")]
	public class Shift
	{
		public Shift()
		{
			EmployeeSchedules = new List<EmployeeSchedule>();
		}
		public Shift(string name, DateTime start, DateTime end) : this()
		{
			Name = name;
			DateStart = start.Date;
			DateEnd = new DateTime(end.Year, end.Month, end.Day, 23, 59, 59, 999);
		}
		public string Name { get; set; }
		public DateTime DateStart { get; set; }
		public DateTime DateEnd { get; set; }
		public List<EmployeeSchedule> EmployeeSchedules { get; set; }
	}
