    List<Int> ObjToList(object[] objects)
    {
        List<int> intList = new list<int>();
        foreach (object o in objects)
        {
            intList.Add((int)o);
        }
        return intList;
    }
