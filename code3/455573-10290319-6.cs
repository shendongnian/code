        Student st = new Student();
        // s1 and s2 will return null if no result found.
        Student s1 = st.getStudent(28, "Minh Sang");
        Student s2 = st.getByIndex(7);
        if (s1 != null)
            Console.WriteLine(s1.Age);
            Console.WriteLine(s1.Name);
        if (s2 != null)
            Console.WriteLine(s2.Age);
            Console.WriteLine(s2.Name);
