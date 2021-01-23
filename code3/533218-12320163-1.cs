    var studentsInGroup1 = arrStudentGroup1.SelectMany(s => new 
                    { 
                        Name = s[0],
                        Number = s[1]
                    });
    var studentsInGroup2 = arrStudentGroup2.SelectMany(s => new 
                    { 
                        Name = s[0],
                        Number = s[1]
                    });
    var studentsInBothGroups = studentsInGroup1.Intersect(studentsInGroup2);
