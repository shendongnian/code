    words = "a*b*c*d*e^1*2*3*4*5^e*f*g*h*i^";
    char[] del = { '^' };
    string[] splitResult = words.Split(del);
    foreach (string w in splitResult)
    {
        char[] separator = { '*' };
        string[] splitR = w.Split(separator);
        if (splitR.Length>=5)
        {
            foreach (string e in splitR)
            {
                string first = splitR[0];
                string second = splitR[1];
                string third = splitR[2];
                string fourth = splitR[3];
                string fifth = splitR[4];
            } 
        }
    }
