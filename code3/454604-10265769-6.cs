        List<Student> students = new List<Student>();
        public List<Student> GetIntersectingStudents(string groupOne, string groupTwo)
        {
            var student = from s in students
                          let grps = s.StudentGroup.ConvertAll(gn => gn.GroupName)
                          where grps.Contains(groupOne) && grps.Contains(GroupTwo)
                          select s;
            return student.ToList();
        }
        public List<Student> GetIntersectingStudents(params string[] groups)
        {
            var student = from s in students
                          let grps = s.StudentGroup.ConvertAll(gn => gn.GroupName)
                          where !groups.Except(grps).Any()
                          select s;
            return student.ToList();
        }
