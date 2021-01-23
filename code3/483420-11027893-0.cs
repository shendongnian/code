    public class MyData
    {
        public int column { get; set; }
        public int row { get; set; }
        public string data { get; set; }
       
    }
  
     List<MyData> listdata = new List<MyData>();
             for (int i = 1; i <= rowCount; i++)
                {
                    for (int j = 1; j <= colCount; j++)
                    {
                        MyData mdata = new MyData();
                        MessageBox.Show(xlRange.Cells[i, j].Value2.ToString());
                        mdata.column=j;
                        mdata.row=i;
                        mdata.data=xlRange.Cells[i, j].Value2.ToString();
                        listdata.Add(mdata);
                    }
                }
