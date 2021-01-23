    if(input1.Length != input2.length)
        return false;
    var characterMap = new Dictionary<char, char>();
    for(int i = 0; i < input1.Length; i++)
    {
        char char1 = input1[i];
        char char2 = input2[i];
        if(characterMap.ContainsKey(char1))
        {
            if(char2 != characterMap[char1])
                return false;
        }
        else
        {
            characterMap[char1] = char2;
        }
    }
    return true;
