    public class MyT1 : MyT
    {
    
    }
    //You list can contains only type of MyT1
    var myList = new MyList<MyT1>();
    
    var myT1 = new MyT1();
    //And you try to add the type MyT to this list.
    MyT myT = myT1.Set("someValue");
    //And here you get the error, because MyT is not the same that MyT1.
    myList.Add(myT);
