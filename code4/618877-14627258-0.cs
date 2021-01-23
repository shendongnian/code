	using System;
	namespace Introduction_to_classes {
		class Person {
			public int Age;
			public string Name;
			public int DateOfBirth() {
				return 2013-Age;
			}
		}
		class Program {
			public static void Main() {
				Person Mother=new Person {
					Age=35,
					Name="Alice"
				};
				Person Son=new Person {
					Age=12,
					Name="Johny"
				};
				Mother.Name="Lucy";  // Just changing the value afterwards
				if(Mother.Age>Son.Age) {
					int year=Mother.DateOfBirth();
					Console.WriteLine("Mom was born in {0}.", year);
				}
				Console.ReadLine();
			}
		}
	}
