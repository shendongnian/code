    DataSet theDataSet = new DataSet();
    theDataSet.ReadXml(@"C:\\Users\mchowdhury\Desktop\MediaInfo.xml");
    StreamWriter theWriter = new StreamWriter("test.xml");
    foreach (DataRow curRow in theDataSet.Tables[0].Rows)
    {
        foreach (DataColumn curCol in theDataSet.Tables[0].Columns)
        {
            theWriter.Write(String.Format("{0} ", curRow[curCol]));
        }
    }
    theWriter.Close();
