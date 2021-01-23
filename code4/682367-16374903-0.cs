    public List<Student> LoadStudents(string STUDENT_FILE)
    {
       var parseQuery = //read all lines from a file
                     from line in File.ReadAllLines(STUDENT_FILE)
                     //split every line on Tab delimiter
                     let split = line.Split(new[] {'\t'})
                     //create new Student object from string array created by split for every line
                     select new Student()
                     {
                       ID = split[0],
                       FirstName = split[1],
                       LastName = split[2]
                     };
         //execute parseQuery, your student objects are now in List<Student>
          var studentList = parseQuery.ToList();
          return studentList;
     }
