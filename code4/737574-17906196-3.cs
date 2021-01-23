    ServiceStudentClient client = new ServiceStudentClient();
    List<Service.ServiceStudent> serviceList = client.GetAllStudents();    
    //Now you need to map your ServiceStudent to ModelStudent here
    List<ModelStudent> modelList = new List<ModelStudent>();
    
    foreach(var serviceStudent in serviceList)
    {
         ModelStudent model = new ModelStudent();
         model.property = serviceStudent.property;
         //Etc etc
         modelList.Add(model);
    }
    //Note : This is just rough code, For mapping you should use Mapper or write your custom method for mapping...
    return View(modelList ); //pass Model Student here...
