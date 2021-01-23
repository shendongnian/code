        Student st = new Student();
        // this will return null if no result found.
        Student s1 = st.getStudent(28, "Minh Sang");
        Student s2 = st.getByIndex(7);
        
        if(s != null)
           Console.WriteLine(s1.Age);
           Console.WriteLine(s1.Name);
           Console.WriteLine(s2.Age);
           Console.WriteLine(s2.Name);
