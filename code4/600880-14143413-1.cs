        public static bool AddToTeacher(SchoolContext db, Student student, Teacher teacher)
        {
            if (student.IsEnrolled)
            {
                teacher.IsCurrentlyTeaching(student);
                return db.SaveChanges() > 0;
            }
            return false;
        }
