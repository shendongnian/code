    string words = "a*b*c*d*e^1*2*3*4*5^e*f*g*h*i^";
    char[] del = { '^' };
    string[] splitResult = words.Split(del,StringSplitOptions.RemoveEmptyEntries);
    foreach (string w in splitResult)
    {
        char[] separator = { '*' };
        string[] splitR = w.Split(separator);
        if(splitR.Length==5)
        {
            string first = splitR[0];
            string second = splitR[1];
            string third = splitR[2];
            string fourth = splitR[3];
            string fifth = splitR[4];
            Console.WriteLine("{0},{1},{2},{3},{4}", first, second, third, fourth, fifth);
        }
    }
