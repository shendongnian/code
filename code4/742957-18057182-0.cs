    string input = "a,[1,2,3,{4,5},6],b,{c,d,[e,f],g},h";
    var delimiterPositions = new List<int>();
    int bracesDepth = 0;
    int bracketsDepth = 0;
    for (int i = 0; i < input.Length; i++)
    {
        switch (input[i])
        {
            case '{':
                bracesDepth++;
                break;
            case '}':
                bracesDepth--;
                break;
            case '[':
                bracketsDepth++;
                break;
            case ']':
                bracketsDepth--;
                break;
            default:
                if (bracesDepth == 0 && bracketsDepth == 0 && input[i] == ',')
                {
                    delimiterPositions.Add(i);
                }
                break;
        }
    }
