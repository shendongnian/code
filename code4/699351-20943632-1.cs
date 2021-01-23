    context.Students.Join(context.Courses, a => a.Course_id, b => b.Course_id, (a, b) => new { Student= a, Course= b }).Where(x => x.Student_id == studentId)
          .Select(y => new
          {
             StudentId = y.Student.StudentId,
             RegistrationNumber = y.Student.RegNo,
             Name = y.Student.Name,
             Coursename = y.Course.Name
          }).ToList();
