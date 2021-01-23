    var list = new List<int>{1,2,3,4,5,6};
    var res = new List<int>();
    for (int i = 0 ; i != list.Count ; i++) {
        for (int j = i+1 ; j != list.Count ; j++) {
            res.Add(list[i]*10+list[j]);
        }
    }
