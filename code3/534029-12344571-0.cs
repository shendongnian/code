    class CommandA : ICommand
    {
      void Execute(object param)
      {
        var commandB = param as CommandB;
        if(commandB != null)
        {
          commandB.Execute((int a) => {
              // continue your code here
            });
        }
      }
    
      bool CanExecute(object param)
      {
        return param is CommandB;
      }
    }
    
    class CommandB : ICommand
    {
      void Execute(object param)
      {
        var action = param as Action<int>;
        if(action != null)
        {
          action(10);
        }
      }
    }
    
    class MVA
    {
      CommandA CommandA{get;}
      CommandB CommandB{get;}
    }
