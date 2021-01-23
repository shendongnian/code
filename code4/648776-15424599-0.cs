	using System;
	public class TaxPayerDemo
	{
    public static void Main()
    {
        Taxpayer[] t = new Taxpayer[2];
        int x;
        for (x = 0; x < t.Length; ++x)
        {
            t[x] = new Taxpayer();//SSN, Gross);
            Console.WriteLine("Type your SSN");
            t[x].SSN = Console.ReadLine();
            Console.WriteLine("Please enter your income");
            t[x].Gross = double.Parse(Console.ReadLine());
			Console.ReadKey();
        }
    }
	
    class Taxpayer
    {
        private string ssn;
        private double gross; 
        private double tax;
        public string SSN
        {
            get
            {
                return ssn;
            }
            set
            {
                CalcTax();
            }
        }
        public double Gross
        {
            get
            {
                return gross;
            }
            set
            {
                CalcTax();
            }
        }
        private void CalcTax()
        {
            if (tax < 30000)
            {
                tax = .15 * Gross;
            }
            else
                if (tax > 30000)
                {
                    tax = .28 * Gross;
                }
            }
        }
    }
