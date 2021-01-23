    private IEnumerable<Tuple<int, ExamMark>> GetMarks()
    {
        ... setup the exam command here
        var reader = examCommand.ExecuteReader();
        while (reader.Read())
        {
            yield return Tuple.Create(
                reader.GetInt32(0),
                new ExamMark
                    {
                        reader.GetInt32(1),
                        reader.GetString(2),
                        reader.GetInt32(3)
                    });
        }
    }
