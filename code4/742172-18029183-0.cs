    // think we have a 
    string teacherName;
    // and a list of 
    string[] subjectNames;
    // then:
    NorthwindCustEntities context = new NorthwindCustEntities();
    
    Teacher t1 = new Teacher() { Name = teacherName };
    t1.Subjects = new List<Subject>();
    foreach(var subject in subjectNames) {
        t1.Subjects.Add(new Subject() { Name = subject });
    }
    
    context.Teachers.Add(t1);
    
    context.SaveChanges();
