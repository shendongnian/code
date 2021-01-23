    Assembly[] assemblies = AppDomain.Current.GetAssemblies();
    Assembly theOne;
    foreach(Assembly assy in assemblies)
    {
       if(assy.FullName == "Company.Web")
       {
           theOne = assy;
           break;
       }
    }
    // Do the rest of your work
