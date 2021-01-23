    using System.IO;
    using LumenWorks.Framework.IO.Csv;
    void ReadCsv()
    {
        // open the file "data.csv" which is a CSV file with headers
        using (CsvReader csv = new CsvReader(
                               new StreamReader("data.csv"), true))
        {
            myDataRepeater.DataSource = csv;
            myDataRepeater.DataBind();
        }
    }
