     void displayCapital(double initalcapital, double interest){
         int year = 1;
         double capital = initialcapital;
         while(initialcapital > capital / 2) {
             Console.Write("Initial capital: ");
             initialcapital = int.Parse(Console.ReadLine());
             Console.Write("Interest: ");
             interest = int.Parse(Console.ReadLine());
             capital = initialcapital * (1 + interest / 100);
             year = year + 1
             Console.Writeline(capital);
         }
    }
