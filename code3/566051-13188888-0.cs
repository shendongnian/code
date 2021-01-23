    Dictionary<string, System.Type> MyDict = new Dictionary<string, System.Type>();
    MyDict.Add("A", typeof(MyAObjectClass));
    MyDict.Add("B", typeof(MyBObjectClass));
    MyDict.Add("C", typeof(MyCObjectClass));
    
    string typeIwant = "B";
    var myobject = Activator.CreateInstance(MyDict[typeIwant]);
