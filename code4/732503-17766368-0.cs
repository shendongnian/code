    Public Class Student
      Public Property Id As String
      Public Property StudentName As String
      Public Property GPA As String
    End Class
    Public Class StudentsSubject
      Public Property SubjectId As String
      Public Property StudentId As String
      Public Property Id As String
    End Class
    Public Class Subject
      Public Property Id As String
      Public Property SubjectName As String
    End Class
    Sub Main()
      Dim students As New List(Of Student)
      students.Add(New Student With {.Id = "1", .GPA = "GPA1", .StudentName = "John"})
      students.Add(New Student With {.Id = "2", .GPA = "GPA2", .StudentName = "Peter"})
  
      Dim subjects As New List(Of Subject)
      subjects.Add(New Subject With {.Id = "100", .SubjectName = "Maths"})
      subjects.Add(New Subject With {.Id = "200", .SubjectName = "Physics"})
      Dim studentsSubject As New List(Of StudentsSubject)
      studentsSubject.Add(New StudentsSubject With {.Id = "10", .StudentId = "1", .SubjectId = "100"})
      studentsSubject.Add(New StudentsSubject With {.Id = "20", .StudentId = "1", .SubjectId = "200"})
      studentsSubject.Add(New StudentsSubject With {.Id = "30", .StudentId = "2", .SubjectId = "100"})
      Dim listOfStudents = From st In students
                           Join ss In studentsSubject On ss.StudentId Equals st.Id
                           Join sb In subjects On ss.SubjectId Equals sb.Id
                           Select st.StudentName, st.GPA, sb.SubjectName
    End Sub
