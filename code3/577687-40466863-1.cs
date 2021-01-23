    //HashSet allows only the unique values to the list
    HashSet<int> uniqueList = new HashSet<int>();
    var a = uniqueList.Add(1);
    var b = uniqueList.Add(2);
    var c = uniqueList.Add(3);
    var d = uniqueList.Add(2); // should not be added to the list but will not crash the app
    //Dictionary allows only the unique Keys to the list, Values can be repeated
    Dictionary<int, string> dict = new Dictionary<int, string>();
    dict.Add(1,"Happy");
    dict.Add(2, "Smile");
    dict.Add(3, "Happy");
    dict.Add(2, "Sad"); // should be failed // Run time error "An item with the same key has already been added." App will crash
    //Dictionary allows only the unique Keys to the list, Values can be repeated
    Dictionary<string, int> dictRev = new Dictionary<string, int>();
    dictRev.Add("Happy", 1);
    dictRev.Add("Smile", 2);
    dictRev.Add("Happy", 3); // should be failed // Run time error "An item with the same key has already been added." App will crash
    dictRev.Add("Sad", 2);
