    public double Parse(string input)
    {
        char lastoperator = '0';
        double result = 0;
        for (int i = 0; i < input.Length; i++)
        {
            string temp = "";
            if (char.IsDigit(input[i]) || input[i] == '.')
                temp += input[i];
            else if(input[i] == '+' || input[i] == '-')
            {
                double val;
                if(double.TryParse(temp, out val))
                {
                    if(lastoperator == '+')
                        result += val;
                    else if(lastoperator == '-')
                        result -= val;
                    else
                        result = val;
                    
                    lastoperator = input[i];
                    temp = "";
                }
                //else error
            }
            else
                continue;
        }
        return result;
    }
