    DataTable dt;
    int dataWidth = 5;  //use a loop or something to determine how many columns will have data
    bool[] emptyCols = new bool[datawidth];  //initialize all values to true
    foreach(Row r in dt)
    {
        for(int i = 0; i < dataWidth; i++)
        {
            if(r[i].Contents != 0))
               emptyCols[i] = false;
        }
    }
    for(int i = 0; i < emptyCols.Length; i++)
    {
         if(emptyCols[i])
            dt.Columns.RemoveAt(i);
    }
