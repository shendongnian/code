	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	namespace ConsoleApplication1
	{
		class Program
		{
			static void Main(string[] args)
			{
				var usersTakenTest = new List<string>() { "Bob", "Jim", "Angel" };
				var allUsers = new List<string> { "Bob", "Jim", "Angel", "Mike", "JimBobHouse" };
				var users = from user in allUsers
							join userTakenTest in usersTakenTest on user equals userTakenTest into tempUsers
							from newUsers in tempUsers.DefaultIfEmpty()
							where string.IsNullOrEmpty(newUsers)
							select user;
							
				foreach (var user in users)
				{
					Console.WriteLine("This user has not taken their test: " + user);
				}
				Console.ReadLine();
			}
		}
	}
