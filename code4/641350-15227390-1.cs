    Partial EntityClassA : InterfaceA
    {
        IEnumerable<InterfaceB> EntityClassBs
        {
            get{ return (some cast or somthin)EntityClassBs;  }
        }
    }
    InterfaceA
    {
       IEnumerable<InterfaceB> CollectionEntityClassBs;
    }
