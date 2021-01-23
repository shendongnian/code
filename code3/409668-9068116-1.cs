    public ActionResult MyFormLetter()
    {
        return View();
    }
    
    [HttpPost]
    public ActionResult MyFormLetter(StudentInformation studentInformation)
    {
        // do what you like with the data passed through submitting the form
        // you will have access to the form data like this:
        //     to get student's name: studentInformation.StudentName
        //     to get teacher's name: studentInformation.TeacherName
        //     to get course's name: studentInformation.CourseName
        //     to get appointment date string: studentInformation.AppointmentDate
    }
