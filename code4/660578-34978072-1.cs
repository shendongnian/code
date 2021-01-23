	class Program
	{
		static void Main(string[] args)
		{
			var schedules = new List<Schedule>();
			schedules.Add(new Schedule("Morning"));
			schedules.Add(new Schedule("Lunch"));
			schedules.Add(new Schedule("Evening"));
			schedules.Add(new Schedule("Night"));
			var shifts = new List<Shift>();
			shifts.Add(new Shift("Week 1", new DateTime(2013, 3, 4), new DateTime(2013, 3, 10)));
			shifts.Add(new Shift("Week 2", new DateTime(2013, 3, 11), new DateTime(2013, 3, 17)));
			shifts.Add(new Shift("Week 3", new DateTime(2013, 3, 18), new DateTime(2013, 3, 24)));
			shifts.Add(new Shift("Week 4", new DateTime(2013, 3, 25), new DateTime(2013, 3, 31)));
			var employees = new List<Employee>();
			employees.Add(new Employee("Fred Smith"));
			employees.Add(new Employee("Charlie Brown"));
			employees.Add(new Employee("Samantha Green"));
			employees.Add(new Employee("Bash Malik"));
			employees.Add(new Employee("Bryan Griffiths"));
			employees.Add(new Employee("Akaash Patel"));
			employees.Add(new Employee("Kang-Hyun Kim"));
			employees.Add(new Employee("Pedro Morales"));
			ShuffleEmployees(ref shifts, schedules, employees);
			var scheduleNameMaxLength = schedules.Max(e => e.Name.Length);
			foreach (var shift in shifts)
			{
				Console.WriteLine($"{shift.Name} ({shift.DateStart:D} - {shift.DateEnd:D})");
				foreach (var map in shift.EmployeeSchedules)
				{
					Console.WriteLine($"- {map.Schedule.Name.PadRight(scheduleNameMaxLength + 1, ' ')}: {map.Employee.Name}");
				}
				Console.WriteLine();
			}
			Console.WriteLine("Press any key to continue ...");
			Console.ReadKey();
		}
		static void ShuffleEmployees(ref List<Shift> shifts, List<Schedule> schedules, List<Employee> employees)
		{
			var maxLength = Math.Max(shifts.Count, schedules.Count);
			var shiftSegmentSize = (employees.Count / maxLength);
			var employeeList = employees.OrderBy(e => Guid.NewGuid()).Take(shiftSegmentSize * maxLength).ToArray();
			for (int shiftIndex = 0; shiftIndex < shifts.Count; shiftIndex++)
			{
				for (int scheduleIndex = 0; scheduleIndex < schedules.Count; scheduleIndex++)
				{
					var employeeIndex = (maxLength + scheduleIndex - shiftIndex) % maxLength;
					for (int segment = 0; segment < shiftSegmentSize; segment++)
					{
						employeeList[employeeIndex + (segment * maxLength)].Schedules.Add(schedules[scheduleIndex]);
						shifts[shiftIndex].EmployeeSchedules.Add(new EmployeeSchedule(employeeList[employeeIndex + segment * maxLength], schedules[scheduleIndex]));
					}
				}
			}
		}
	}
