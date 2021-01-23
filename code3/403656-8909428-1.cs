    var result = (from s in students
              where s.Subjects.Any(subj => subj.SubjectID == yourValue)
              select new Student
              {
                  Name = s.StudentName
                  Subjects = s.Subjects.Where(subj => subj.SubjectID == yourValue).ToList());    
              }
