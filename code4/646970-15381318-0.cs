    public static List<Student> FilteredStudents(int[] targetIds)
    {
        var allStudents = GetAllStudents().ToDictionary(student => student.id);
        var result = new List<Student>();
        foreach (int id in targetIds)
        {
            Student student;
                
            if (allStudents.TryGetValue(id, out student))
            {
                result.Add(student);
            }
        }
            
        return result;
    }
