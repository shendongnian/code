        private static DataSet SampleData()
        {
            DataSet sampleDataSet = new DataSet();
            sampleDataSet.Locale = CultureInfo.InvariantCulture;
            DataTable sampleDataTable = sampleDataSet.Tables.Add("SampleData");
 
            sampleDataTable.Columns.Add("FirstColumn", typeof(string));
            sampleDataTable.Columns.Add("SecondColumn", typeof(string));
            DataRow sampleDataRow;
            for (int i = 1; i <= 49; i++)
            {
                sampleDataRow = sampleDataTable.NewRow();
                sampleDataRow["FirstColumn"] = "Cell1: " + i.ToString(CultureInfo.CurrentCulture);
                sampleDataRow["SecondColumn"] = "Cell2: " + i.ToString(CultureInfo.CurrentCulture);
                sampleDataTable.Rows.Add(sampleDataRow);
            }
 
            return sampleDataSet;
        }
