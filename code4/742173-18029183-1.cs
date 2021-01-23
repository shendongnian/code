    NorthwindCustEntities context = new NorthwindCustEntities();
    Teacher t1 = new Teacher() { Name = "Jane Smith" };
    Subject s1 = new Subject() { Name = "Math" };
    Subject s2 = new Subject() { Name = "Science" };
    t1.Subjects.Add(s1);
    t1.Subjects.Add(s2);
    context.Teachers.Add(t1);
    context.SaveChanges();
