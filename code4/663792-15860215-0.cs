		interface IHasNameAndAge
		{
			string Name { get; }
			int Age { get; }
		}
		class A : IHasNameAndAge
		{
			public string Name { get; set; }
			public int Age { get; set; }
			string Email { get; set; }
			public A(string name, int age, string email)
			{
				Name = name;
				Age = age;
				Email = email;
			}
		}
		class B : IHasNameAndAge
		{
			public string Name { get; set; }
			public int Age { get; set; }
			string Location { get; set; }
			public A(string name, int age, string location)
			{
				Name = name;
				Age = age;
				Location = location;
			}
		}
		void Output(IHasNameAndAge obj)
		{
			Console.WriteLine(obj.Name + " is " + obj.Age);
		}
