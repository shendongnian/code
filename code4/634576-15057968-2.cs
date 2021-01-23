    internal class Program
    {
        private const string ErrMsg = "Error, enter a number";
        private static void Main(string[] args)
        {
            double loanPayment, insurance, gas, oil, tires, 
                   maintenance, monthlyTotal, annualTotal;
            Console.WriteLine("Please enter the following expenses on a per month basis");
            GetInput(out loanPayment, "loan payment");
            GetInput(out insurance, "insurance");
            GetInput(out gas, "gas");
            GetInput(out oil, "oil");
            GetInput(out tires, "tires");
            GetInput(out maintenance, "maintenance");
            Calculate(out monthlyTotal, out annualTotal, loanPayment, insurance, gas, oil, tires, maintenance);
            
            Console.WriteLine("----------------------------");
            Console.WriteLine("Your monthly total is ${0:F2} and your annual total is ${1:F2}", monthlyTotal, annualTotal);
            Console.WriteLine("----------------------------");
            Console.ReadLine();
        }
        private static void GetInput(out double value, string message)
        {
            Console.WriteLine("How much is the {0}?", message);
            while (!double.TryParse(Console.ReadLine(), out value))
                Console.WriteLine(ErrMsg);
        }
        private static void Calculate(out double monthlyTotal, out double annualTotal, double loanPayment,
                                      double insurance, double gas, double oil, double tires, double maintenance)
        {
            monthlyTotal = loanPayment + insurance + gas + oil + tires + maintenance;
            annualTotal = monthlyTotal * 12;
        }
    }
