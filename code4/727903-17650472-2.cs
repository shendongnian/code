    private IEnumerable<Student> GetStudents()
    {
        var resultLookup = GetMarks().ToLookup(t => t.Item1, t => t.Item2);
        ... setup the student command here
        var reader = studentCommand.ExecuteReader();
        while (reader.Read())
        {
            var studentId = reader.GetInt32(0);
            yield return new Student
                    {
                        studentId,
                        reader.GetString(1),
                        resultLookup[studentId].ToList()
                    });
        }
    }
