    string FilterCond1 = "id=" + getId;
    DataRow[] myrow = DataTable.Select(FilterCond1);
    if (myrow.Length > 0)
    {
      for(int i = 0; i < myrow.Length; i ++)
      {
        if(myrow[i]["size"].ToString() == "28")
        {
          // YOUR CODE HERE 
        }
      }
    }
    else
    {
    }
