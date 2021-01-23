    enum PrimaryColors
    {        
        Red = 0,
        Yellow = 2,
        Blue = 4
    }
    enum SecondaryColors
    {
        Orange = 1,
        Green = 3,
        Purple = 5
    }
    //Combine them into a new enum somehow to result in:
    enum AllColors
    {
        Red = 0,
        Orange,
        Yellow,
        Green,
        Blue,
        Purple
    }
    class Program
    {
        static AllColors ParseColor(Enum color)
        {
            return ParseColor(color.ToString());
        }
        static AllColors ParseColor(string color)
        {
            return (AllColors)Enum.Parse(typeof(AllColors), color);
        }
        static void Main(string[] args)
        {
            PrimaryColors color1=PrimaryColors.Red;
            AllColors result=(AllColors)color1;
            // AllColors.Red
            SecondaryColors color2=SecondaryColors.Green;
            AllColors other=(AllColors)color2; 
            // AllColors.Green
            AllColors final=ParseColor(PrimaryColors.Yellow);
            // AllColors.Yellow
        }
    }
