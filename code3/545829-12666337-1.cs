    var list = new List<int>{98,76,54,32,10};
    var res = new List<int>();
    for (int i = 0 ; i != list.Count ; i++) {
        for (int j = i+1 ; j != list.Count ; j++) {
            res.Add(int.Parse(string.Format("{0}{1}", list[i], list[j])));
        }
    }
