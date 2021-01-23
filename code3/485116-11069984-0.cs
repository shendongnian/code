     List<Student> lst = new List<Student>();
               lst.Add(new Student {ID = 1});
               lst.Add(new Student {ID = 2});
    //Get the student you want by id then use that to populate the remaining properties 
               var temp = lst.Where(l => l.ID == 1).Single();
               temp.FirstName = "fname";
               temp.LastName = "lastname";
