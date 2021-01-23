     List<Test> tests = new List<Test>();
     tests.Add(new Test() { Id = 1, Name = "name1" });
     tests.Add(new Test() { Id = 2, Name = "name2" });
     tests.Add(new Test() { Id = 3, Name = "name3" });
     tests.Add(new Test() { Id = 4, Name = "name2" }); 
     var r = tests.Find(p => p.Name == "name2");
     Console.WriteLine(r.Id);
