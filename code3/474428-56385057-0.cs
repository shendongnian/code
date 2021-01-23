    int [] array = {1,2,3,4};
    Type t1 = array.GetType();
    // t1.IsArray == true
    List<int> list = new List();
    list.AddRange(array);
    Type t2 = list.GetType();
    //t2.IsArray = false;
    //t2.IsSerializable = true;
    foreach(var i in list) {
            // do stuff
    }
