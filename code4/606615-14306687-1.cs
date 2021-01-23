    Int32 weeklySales = 0;
    while (weeklySales.Equals(0))
    {
        Console.WriteLine("Weekly sales:");
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
    Console.Write("\nYour Weekly Sale amount is :\t\t" + weeklySales+ "\n\nGross Pay:\t\t\t\t" + grossPay+ "\n\nFed Tax \t\t\t\t" + fedTax + "\n\nRetirement\t\t\t\t"+ retirement + "\n\nSocial Security:\t\t\t" + socSecurity + "\n\nTotal Deductions:\t\t\t" + totDeductions + "\n\nMaking your take home pay:\t\t" + takeHomePay);
    Console.Read();
