    void Main()
    {
    	var allSalaries = new List<SalaryInformation> {
    	new SalaryInformation("doctor", 1, 100, 120), 
    	new SalaryInformation("doctor", 1, 120, 150), 
    	new SalaryInformation("engineer", 1, 50, 100)};
    	
    	var profession = (from x in allSalaries
    	group x by x.Profession into g
    	select new {Profession = g.Key, SalaryAvr = g.Average (x => x.CurrentSalary)})
    	.OrderByDescending (g => g.SalaryAvr)
    	.FirstOrDefault().Profession;
    	
    	Console.WriteLine(profession);
    }
    
    public class SalaryInformation
    {
        private string profession;
        private int yearOfEmployment;
        private decimal startSalary;
        private decimal currentSalary;
    
        public string Profession
        {
            get { return profession; }
            set { profession = value; }
        }
    
        public int YearOfEmployment
        {
            get { return yearOfEmployment; }
            set { yearOfEmployment = value; }
        }
    
        public decimal StartSalary
        {
            get { return startSalary; }
            set { startSalary = value; }
        }
    
    
        public decimal CurrentSalary
        {
            get { return currentSalary; }
            set { currentSalary = value; }
        }
    
        public SalaryInformation()
        { }
    
        public SalaryInformation(string p, int yoe, decimal startS, decimal currentS)
        {
            profession = p;
            yearOfEmployment = yoe;
            startSalary = startS;
            currentSalary = currentS;
        }
    }
