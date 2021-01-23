    public static IQueryable<Student> OrderByMarks(this IQueryable<Student> students)
    {
        return students.OrderBy(student => student.ExamData
            .OrderByDescending(exam => exam.ExamDate)
            .ThenBy(exam => exam.ExamId)
            .FirstOrDefault().TotalMarks);
    }
