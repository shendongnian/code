        System.Data.DataTable tb = new System.Data.DataTable();
        System.Data.DataTable tb2 = new System.Data.DataTable();
        object obj = new object();
        obj = tb.Copy();//adding to obj if you want....
        tb2 = tb.Copy();// of to another table without carrying the reference
