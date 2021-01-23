    public interface ICommandWithResult<T> : ICommand
    {
      T Result { get; }
    }
    
    public class CalculateSalaryCommand : ICommandWithResultOf<int>
    {
      public int Result { get; private set; }
      // ...
    
      public void Execute()
      {
        _salaryTs.CalculateSalary(_hour, _salaryPerHour);
        this.Result = _salaryTs.Result;
      }
    }
    
    // Usage:
    var command = new CalculateSalaryCommand(new CalculateSalaryTS(), 10, 20);
    command.Execute();
    Console.WriteLine("Salary is {0}", command.Result);
