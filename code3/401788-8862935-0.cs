        interface ICommand<TResult>
        {
           TResult Execute();
        }
    
    
    public class CalculateSalaryCommand : ICommand<int>
    {
        private readonly CalculateSalaryTS _salaryTs;
        private readonly int _hour;
        private readonly int _salaryPerHour;
    
        public CalculateSalaryCommand(CalculateSalaryTS salaryTs, int hour, int salaryPerHour)
        {
            _salaryTs = salaryTs;
            _hour = hour;
            _salaryPerHour = salaryPerHour;
        }
    
        public int Execute()
        {
            return _salaryTs.CalculateSalary(_hour, _salaryPerHour);
        }
    }
