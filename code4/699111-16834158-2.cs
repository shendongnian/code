    public static class CourseExt
    {
        public static int ShowGrade(this Course course, int grade)
        {
            return course.s.ShowGrade(grade);
        }
    }
    ...
    Console.WriteLine(list[0].ShowGrade(0));
