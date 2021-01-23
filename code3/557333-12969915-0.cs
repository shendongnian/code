	class Program
	{
		static int age;
		static void Main(string[] args)
		{
			string answer;
			{
				Console.WriteLine("please enter your name:");
				string name = Console.ReadLine();
				Console.WriteLine("please enter your surname:");
				string surname = Console.ReadLine();
				Console.WriteLine("please enter your age:");
				age = Convert.ToInt32(Console.ReadLine());
				Console.WriteLine("please enter your adress:");
				string adress = Console.ReadLine();
				Console.WriteLine("hallo,{0} {1},veel sucess met C#", name, surname);
				Console.WriteLine("zijn deze gegevens juist? J/N");
				answer = Console.ReadLine();
			}
			while (answer == "N");
			for (int i = 0; i < 3; i++)
			{
				if (age >= 0 && age <= 10)
				{
					// First age group.
				}
				if (age >= 11 && age <= 20)
				{
					// Second age group.
				}
				if (age >= 21 && age <= 65)
				{
					// Third age group.
				}
			}
		}
	}
