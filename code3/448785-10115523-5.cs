    public ActionResult ShowStudent(string StudentID)
    {
        Student s;
        while( (s=students.FirstOrDefault( x => x.StudentId == StudentId )) == null ) {
            StudentId = "0" + StudentId;
            if( StudentId.Length > 15 ) break;
        }
        return View( s );
    }
