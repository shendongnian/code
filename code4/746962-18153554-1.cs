    using (fs =new FileStream(NewFileName, FileExists ? FileMode.Append : FileMode.Create)) {
        sw = new StreamWriter(fs);
        MessageBox.Show(Record);
        sw.WriteLine(Record);
        sw.Close(); // <<== Add this line
        fs.Close();
    }
