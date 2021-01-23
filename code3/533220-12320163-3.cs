    var studentsInGroup1 = arrStudentGroup1.SelectMany(s => new 
                    { 
                        Name = s[0],
                        Score = s[1]
                    });
    var studentsInGroup2 = arrStudentGroup2.SelectMany(s => new 
                    { 
                        Name = s[0],
                        Score = s[1]
                    });
    var studentsInBothGroups = studentsInGroup1.Join(
            studentsInGroup2,
            s => s.Name,
            s => s.Name,
            (one, two) => new 
                 { 
                     Name = one.Name, 
                     Scores = new[] { one.Score, two.Score }
                 });
