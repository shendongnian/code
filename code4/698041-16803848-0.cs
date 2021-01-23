    int count = l1.Count;
    Dictionary<string, string> dict = new Dictionary<string, string>();
    
    for (int i = 0; i <= count; i++) {
        string s1 = l1(i);
        string s2 = l2(i);
        if (!s1.Equals(s2)) {
            if (!s1[0].Equals(s2[0])) {
                dict.Add(s1, s2);
            } else {
                    //magicMethod();
                    }
        } else {
            //magicMethod();
        }
    }
