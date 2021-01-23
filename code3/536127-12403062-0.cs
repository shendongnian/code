    System.Collections.Hashtable myHashtable1 = new System.Collections.Hashtable();
                    myHashtable.Add(dset.Tables[0].Rows[0]["Column1"], myDataTable1.Rows[0]["Column2"]);
                    myHashtable.Add(dset.Tables[0].Rows[1]["Column1"], myDataTable1.Rows[1]["Column2"]);
    System.Collections.Hashtable myHashtable2 = new System.Collections.Hashtable();
                    myHashtable.Add(dset.Tables[1].Rows[0]["Column1"], myDataTable1.Rows[0]["Column2"]);
                    myHashtable.Add(dset.Tables[1].Rows[1]["Column1"], myDataTable1.Rows[1]["Column2"]);
    var result = myHashtable2 .SetEquals(myHashtable1);
    if (result == true)
    {
    found = 1;
    }
