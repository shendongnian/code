    string strHidden = new String(Enumerable.Range(0, strNum.Length)
        .Select(i => 
            char.IsNumber(strNum[i]) && 
            Enumerable.Range(i+1,2).All(j => j < strNum.Length && char.IsNumber(strNum[j]))
                ? 'X'
                : strNum[i])
        .ToArray());
