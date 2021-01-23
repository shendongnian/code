		static void Main() {
			Gateway gate = new Gateway();
			Console.WriteLine("Student id1 looks up Staff id2: {0}", gate.DoSomethingWithPerson(new Student("id1"), "id2"));
			Console.WriteLine("Staff id2 looks up Student id1: {0}", gate.DoSomethingWithPerson(new Staff("id2"), "id1"));
			Console.ReadLine();
		}
