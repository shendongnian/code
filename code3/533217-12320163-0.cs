    var studentsInGroup1 = arrStudentGroup1.SelectMany(group => new 
                    { 
                        Name = group[0],
                        Number = group[1]
                    });
    var studentsInGroup2 = arrStudentGroup2.SelectMany(group => new 
                    { 
                        Name = group[0],
                        Number = group[1]
                    });
    var studentsInBothGroups = studentsInGroup1.Intersect(studentsInGroup2);
