    Partial EntityClassA : InterfaceA
    {
        IEnumerable<InterfaceB> CollectionEntityClassBs
        {
            get{ return (some cast or somthin)EntityClassBs;  }
        }
    }
    InterfaceA
    {
       IEnumerable<InterfaceB> CollectionEntityClassBs;
    }
