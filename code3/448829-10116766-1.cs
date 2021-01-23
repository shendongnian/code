    System.Runtime.Serialization.Formatters.Binary.BinaryFormatter BinFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
    string fname;
    System.IO.FileStream FS = new System.IO.FileStream("C:\\tv.xml", IO.FileMode.Open);
    listview1.Items.AddRange(BinFormatter.Deserialize(FS).ToArray(typeof(ListViewItem)));
    FS.Close();
