    public void DoSomething(User user){
      if (user is Employee)
      {
        employeeService.DoSomething(user);
      }
      else if (user is Manager)
      {
        managerService.DoSomething(user);
      }
      else if (user is Executive)
      {
        executiveService.DoSomething(user);
      }
    }
