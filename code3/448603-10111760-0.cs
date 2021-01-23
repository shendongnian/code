      public void AddStudentToGroup(string group, string studentID, string firstName, string lastName)
        {
            var result = Groups.Where(n => String.Equals(n.GroupName, group)).FirstOrDefault();
            var result1 = students.Where(n => String.Equals(n.StudentID, studentID)).FirstOrDefault();
            if (result != null)
            {
                result.Groupsz.Add(new Student() { StudentID = studentID, FirstName = firstName, LastName = lastName });
            }
            if (result1 != null)
            {
                result1.StudentGroup.Add(new Group() { GroupName = group });
            }
        }  
