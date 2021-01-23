    public string GenerateUI()
    {    
    if(Student.IsEnrolled)
      return EnrolledStudentModel.GenerateUI();
    else
      return UnenrolledStudentModel.GenerateUI();
    }
