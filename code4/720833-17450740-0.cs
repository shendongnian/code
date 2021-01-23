    namespace ConsoleApplication4   {
        class Program
    {
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
        doc.LoadXml(@"<table border='1' cellpadding='0' cellspacing='0'>
                    <tr>
                    <td width='50%'>cell 1a</td>
                    <td width='50%'>cell 1b</td>
                    </tr>
                    <tr>
                    <td width='50%'>cell 2a</td>
                    <td width='50%'>cell 2b</td>
                    </tr>
                    </table>");
        DataTable dt = new DataTable();
        dt.Columns.Add("Col1");
        dt.Columns.Add("Col2");
        foreach (XmlNode ndRow in doc.DocumentElement.ChildNodes)
        {
        DataRow dr = dt.NewRow();
        for (int colIndex = 0; colIndex < ndRow.ChildNodes.Count; colIndex++)
        dr[colIndex] = ndRow.ChildNodes[colIndex].InnerText;
        dt.Rows.Add(dr);
        }
        foreach (DataRow r in dt.Rows) {
            Console.Write(r[0] + " --- " + r[1] );
            Console.WriteLine("");
        }
        Console.ReadLine();
    }
        }
    }
