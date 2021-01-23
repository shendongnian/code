    var results = new List<Student>();
    foreach (var person in people)
    {
        var student = person as Student;
        if (student != null && student.Grade > 7m)
        {
             results.Add(student);
        }
    }
