    public void TestingOperationOneWay()
    {
        int[] list;
        /* Populate list with a bunch of id numbers found in myOBjs */
        myCont data = new myCont();
        myObj ob = data.myObjs.Where(o => o.parent == "number1");
        foreach(int i in list)
        {
            ob.First(o => o.id == i && o.received != true).received = true;
        }
    }
