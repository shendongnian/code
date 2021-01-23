    var query = from s in db.Student
                join scg in db.StudentCourseGroup on s.StudentID equals scg.StudentID
                join c in db.Course on scg.CourseID equals c.CourseID
                join g in db.Group on scg.GroupID equals g.GroupID
                where c.CourseName == "xyz"
                select new { s, g } into x
                group x by x.s into studentGroups
                select new MyStudent {
                    StudentName = studentGroups.Key.StudentName,
                    Groups = studentGroups.Select(sg => sg.g.GroupName)
                };
