    public static void add1<T>(Items items) where T : IofMine
    {
            List<T> temp = (List<T>)(object)items.MyList;
            var toAdd = new List<T>();
            ofMine of = new ofMine() { i = 0 };
            toAdd.Add((T)(IofMine)of);
            temp.AddRange(toAdd);
    }
