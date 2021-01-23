    public ActionMethod Index(int? studentID)
    {
      var model = new StudentModelView 
      {
        StudentId = studentID, 
        SelectPeopleList=GetListFiltered(studentId)  
      }
      return(model);
    }
