     ServiceController[] services = ServiceController.GetServices();
    foreach(Service ser in services )
    {
      if(ser.Status==ServiceControllerStatus.Running)
       {
            Response.Write("Service is running");
       }
       else
        {
            Response.Write("Service is stopped");
        }
    }
