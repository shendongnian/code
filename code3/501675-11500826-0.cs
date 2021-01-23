    var dt = new DataTable();
    dt.Columns.Add("foo", typeof (int));
    dt.Columns.Add("bar", typeof(string));
    
    dt.RemotingFormat = SerializationFormat.Binary;
    var ser = new BinaryFormatter();
    using(var ms = new MemoryStream())
    {
        dt.Rows.Add(123, "abc");
        ser.Serialize(ms, dt); // batch 1
        dt.Rows.Clear();
        dt.Rows.Add(456, "def");
        ser.Serialize(ms, dt); // batch 2
        ms.Position = 0;
        var table1 = (DataTable) ser.Deserialize(ms);
        // the following is the merge loop that you'd repeat until EOF
        var table2 = (DataTable) ser.Deserialize(ms);
        foreach(DataRow row in table2.Rows) {
            table1.ImportRow(row);
        }
        // show the results
        foreach(DataRow row in table1.Rows)
        {
            Console.WriteLine("{0}, {1}", row[0], row[1]);
        }
    }
