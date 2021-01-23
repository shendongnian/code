    //combine all lists into a single IEnumerable<string>
    IEnumerable<string> unionList = ExceptionCM.Union(ExceptionPM)
                                                  .Union(ExceptionDL)
                                                      .Union(ExceptionCL);
    
    //check against union list
    if(unionList .Any(s => !ddl_model.SelectedValue.Contains(s)) )
    {
       //do something
    }
