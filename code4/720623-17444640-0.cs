    for(int i=0;i<MyDataset.Tables[0].Columns.count;i++)
    {
    DataRow[] MyDR=MyDataset.Tables[0].Select(MyDataSet.Tables[0].Columns[i].ToString()+"='"+MyText+"'");
 
       if(MyDr.Length>0)
       {
       //You Found the item
       }
    }
