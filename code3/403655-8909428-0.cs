    var result = (from s in Student 
              where s.Subjects.Any(subj => subj.SubjectID == yourValue)
              select new Student
              {
                  Name = s.StudentName
                  Subjects = s.Where(subj => subj.SubjectID = yourValue).ToList());    
              }
