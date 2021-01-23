    public class CoolCommand : ICommand
    {
        #region ICommand Members
    
        public bool CanExecute(object parameter)
        {
            return true;
        }
    
        public event EventHandler CanExecuteChanged;
    
        public void Execute(object parameter)
        {
           //do what you want :)
        }
    
        #endregion
    }
    var allCommands = new List<ICommand>();
    allCommands.Add(new CoolCommand);
    allCommands.Add(new OtherCoolCommand);
    allCommands.Add(new ThirdCoolCommand);
    
    private void assignButton(button)
    {
        var idx = new Random().nextInt(allCommands.Count-1);
        var command = allComands[idx];
        button.Command = command;
        allCommands.remove(command);
    }
