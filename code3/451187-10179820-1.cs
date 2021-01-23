    public static IEnumerable<StudentCourse> GetCourses()
    {
        using (var conn = new SqlConnection(SomeConnectionString))
        using (var cmd = conn.CreateCommand())
        {
            conn.Open();
            cmd.CommandText = "select st.firstname + ' ' + st.lastname, se.year, c.coursename, c.NumberOfCredits, ri.mark from Students st inner join RegisteredIn ri on ri.StudentId=st.id inner join Semester se on se.id=ri.SemesterId inner join Courses c on c.id=se.id";
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    yield return new StudentCourse
                    {
                        Name = reader.GetString(0),
                        Year = reader.GetInt32(1),
                        ... and so on
                    }; 
                }
            }
        }
    }
