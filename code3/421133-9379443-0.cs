    var query = from s in students
                join s2 in students.Where(x => x.StudentId != s.StudentId) on s.FamilyId equals s2.FamilyId into siblings
                select new
                {
                  Student = s,
                  Siblings = siblings,
                };
         
