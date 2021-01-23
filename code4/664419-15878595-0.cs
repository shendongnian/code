    public struct Parameters
    {
        public int X {get; set;}
        public int Y {get; set;}
    }
    public Parameters ExtractParameters(string amountUnit)
    {    
        var parameters = new Parameters();
        if (amountUnit.ToLower().Contains("x"))
        {
            string[] amount = amountUnit.Split('x');
            parameters.X = int.Parse(amount[0].Trim());
            parameters.Y = int.Parse(amount[1].Trim());
        }
        else
        {
            parameters.X = 1;
            parameters.Y = int.Parse(amountUnit.Trim());
        }
        return parameters;
    } 
