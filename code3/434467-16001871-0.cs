    static void Main()
    {
        double sum = 0;
        int n = 1111111; // binary number
        int strn = n.ToString().Length; //how many digits has my number
        for (int i = 0; i < strn; i++)
        {
            int lastDigit = n % 10; // get the last digit
            sum = sum + lastDigit * (Math.Pow(2, i));
            n = n / 10; //remove the last digit
        }
        Console.WriteLine(sum);
    }
}
