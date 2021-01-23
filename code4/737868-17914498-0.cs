	public class Course
	{
		public string CourseName;
		public int CourseNumber;
		public int StudentsNumber;
		public string TeacherName;
		public string ClassNumber;
		
		public static Course ReadCourse()
		{
			var rez = new Course();
			
			Console.WriteLine("Enter the Course's name, course's number, students number, teacher's name, and class' number\n");
			rez.CourseName = Console.ReadLine().ToString();
			rez.CourseNumber = int.Parse(Console.ReadLine());
			rez.StudentsNumber = int.Parse(Console.ReadLine());
			rez.TeacherName = Console.ReadLine().ToString();
			rez.ClassNumber = Console.ReadLine().ToString();
			
			return rez;
		}
	}
	
	public class Program
	{	
		void Main()
		{
			var courses = new List<Course>();
			
			int actionChoice;
			while(1=1)
			{
				Console.WriteLine("What do you want to do? (Enter number): \n  1) Add a new Course \n 2)Add a new class room \n 3)Add an existing class to an existing classroom \n 4)Read the information of a specific classroom \n 5)Read the information of all the classrooms \n 6)Read the information of a specific course \n 7)Delete a specific course \n 8)Update courses in the Time Table \n 9)Exit the program  \n");
				actionChoice = int.Parse(Console.ReadLine());
				
				switch (actionChoice)
				{
				
					case 1: //Add a new Course
						var new_course = Course.ReadCourse();
						courses.Add(new_course);	
						break;
					
					case 9:	// Exit
						return;
					default:
						Console.WriteLine("Wrong input");
				}
			}
		}
	}
