    internal class Program
    {
        private const string ErrMsg = "Error, enter a number";
        private static void Main(string[] args)
        {
            double loanPayment;
            double insurance;
            double gas;
            double oil;
            double tires;
            double maintenance;
            double monthlyTotal;
            double annualTotal;
            Console.WriteLine("Please enter the following expenses on a per month basis");
            GetInput(out loanPayment, out insurance, out gas, out oil, out tires, out maintenance);
            Calculate(out monthlyTotal, out annualTotal, loanPayment,  insurance,  gas,  oil, tires, maintenance);
            Console.WriteLine("----------------------------");
            Console.WriteLine("Your monthly total is ${0:F2} and your annual total is ${1:F2}", monthlyTotal,
                              annualTotal);
            Console.WriteLine("----------------------------");
            Console.ReadLine();
        }
        private static void GetInput(out double loanPayment, out double insurance, out double gas, out double oil,
                                     out double tires, out double maintenance)
        {
            Console.WriteLine("How much is the loan payment?");
            while (!double.TryParse(Console.ReadLine(), out loanPayment))
                Console.WriteLine(ErrMsg);
            Console.WriteLine("How much is the insurance?");
            while (!double.TryParse(Console.ReadLine(), out insurance))
                Console.WriteLine(ErrMsg);
            Console.WriteLine("How much is the gas?");
            while (!double.TryParse(Console.ReadLine(), out gas))
                Console.WriteLine(ErrMsg);
            Console.WriteLine("How much is the oil?");
            while (!double.TryParse(Console.ReadLine(), out oil))
                Console.WriteLine(ErrMsg);
            Console.WriteLine("How much is the tires?");
            while (!double.TryParse(Console.ReadLine(), out tires))
                Console.WriteLine(ErrMsg);
            Console.WriteLine("How much is the maintenance?");
            while (!double.TryParse(Console.ReadLine(), out maintenance))
                Console.WriteLine(ErrMsg);
        } 
        private static void Calculate(out double monthlyTotal, out double annualTotal, double loanPayment,
                                      double insurance, double gas, double oil, double tires, double maintenance)
        {
            monthlyTotal = loanPayment + insurance + gas + oil + tires + maintenance;
            annualTotal = monthlyTotal*12;
        }
    }
