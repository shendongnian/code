    public class Fraction
    {
        decimal Denominator {get;set;}
        decimal Numerator {get;set;}
        public Fraction(decimal denum, decimal num)
        {
            Denominator = denum;
            Numearator = num;
        }
         //this way you can instantiate a fraction object with any value of your choice
    }
