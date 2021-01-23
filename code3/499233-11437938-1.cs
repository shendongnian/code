    public string GetResultsWithHyphen(string input)
    {
    string output = "";
            int start = 0;
            while (start < input.Length)
            {
                char bla = input[start];
                output += bla;
                start += 1;
                if (start % 4 == 0)
                {
                    output += "-";    
                }
            }
    return output;
    }
