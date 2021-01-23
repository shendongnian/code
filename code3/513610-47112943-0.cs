    void Main()
    {
    	Console.WriteLine(RoundUp(2.8448M, 2));
    	//RoundUp(2.8448M, 2).Dump();
    }
    
    public static decimal RoundUp(decimal numero, int numDecimales)
    {
        decimal valorbase = Convert.ToDecimal(Math.Pow(10, numDecimales));
        decimal resultado = Decimal.Round(numero * 1.00000000M, numDecimales + 1, MidpointRounding.AwayFromZero) * valorbase;
        decimal valorResiduo = 10M * (resultado - Decimal.Truncate(resultado));
    
        if (valorResiduo < 5)
        {
            return Decimal.Round(numero * 1.00M, numDecimales, MidpointRounding.AwayFromZero);
        }
        else
        {
            var ajuste = Convert.ToDecimal(Math.Pow(10, -(numDecimales + 1)));
            numero += ajuste;
            return Decimal.Round(numero * 1.00000000M, numDecimales, MidpointRounding.AwayFromZero);
        }
    }
