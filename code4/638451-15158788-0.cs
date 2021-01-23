    ServiceController service = null;
    
    try {
      service = new ServiceController(serviceName);
      
      if (service.Status == ServiceControllerStatus.Running) {
        return true;
      }
      else {
        return false;
      }
    }
    finally{
      if (service != null) {
        service.Close(); // or service.Dispose();
      }
    }
