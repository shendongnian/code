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
			}
			
			for (x = 0; x < t.Length; ++x)
			{
                                t[x].CalcTax();
				Console.WriteLine(t[x].SSN + " " + t[x].Gross + " " + t[x].Tax);
			}
							
			Console.ReadKey();
		}
    }
	
    class Taxpayer
    {
        public double Tax { get; set; }
        public string SSN { get; set; }
        public double Gross { get; set; }
        public void CalcTax()
        {
            if (Gross < 30000)
            {
                Tax = .15 * Gross;
            }
            else if (Gross >= 30000)
            {
                Tax = .28 * Gross;
            }
        }
    }
