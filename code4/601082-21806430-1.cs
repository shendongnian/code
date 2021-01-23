    using(var context = new StudentClassContext())
    { 
         Class aClass = new Class{ ClassName = "Gym", Students = new Student(){ StudentName="Johnny"}}
         context.Classes.Add(aClass);
         context.SaveChanges();
    }
