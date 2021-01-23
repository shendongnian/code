    using(var enu = IEnumFromStream.GetEnumerator())
    {
        //You have to call "MoveNext()" once before getting "Current" the first time,
        //   this is done so you can have a nice clean while loop like this.
        while(enu.MoveNext())
        {
            Container = enu.Current;
        }
    }
