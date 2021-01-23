    Int32 weeklySales = 0;
    while (weeklySales.Equals(0))
    {
        Console.WriteLine("What are your weekly sales?");
        String input = Console.ReadLine();
        try
        {
            weeklySales = Int32.Parse(input);
        }
        catch
        {
            Console.WriteLine("There is an error in your input, try again!");
        }
    }
    Double grossPay = weeklySales * .07;
    Double fedTax = grossPay * .18;
    Double retirement = grossPay * .1;
    Double socSecurity = grossPay * .06;
    Double totDeductions = socSecurity + retirement + fedTax;
    Double takeHomePay = grossPay - totDeductions;
    Console.Write("\nYour Weekly Sale amount is :" + weeklySales + "$\nGross Pay: " + grossPay + "$\nFed Tax: " + fedTax + "$\nRetirement: " + retirement + "$\nSocial Security: " + socSecurity + "$\nTotal Deductions: " + totDeductions + "$\nMaking your take home pay: " + takeHomePay + "$");
    Console.Read();
