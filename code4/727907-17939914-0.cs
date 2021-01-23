    using (SqlDataReader reader = command.ExecuteReader())
            {
                var records = (from record in sqlReader.Cast<DbDataRecord>()
                               select new
                               {
                                   StudentID = record.GetInt32(0),
                                   StudentName = record.GetString(1),
                                   ExamID = record.GetInt32(2),
                                   ExamName = record.GetString(3),
                                   Mark = record.GetInt32(4)
                               })
                               .GroupBy(r => new { StudentID = r.StudentID, StudentName = r.StudentName })
                               .Select(
                                         r => new Student
                                         {
                                             StudentID = r.Key.StudentID,
                                             StudentName = r.Key.StudentName,
                                             examResults = r.Select(e => new ExamMark
                                             {
                                                 ExamID = e.ExamID,
                                                 ExamName = e.ExamName,
                                                 Mark = e.Mark
                                             }).ToList()
                                         });
            }
