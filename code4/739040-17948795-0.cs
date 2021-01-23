    Dictionary<string,string> dic = new Dictionary<string,string>();
    
    for (int i = 0; i < listOfAtt.Count; i+=2) {
        dic.Add(listOfAtt[i], listOfAtt[i + 1]);
    }
