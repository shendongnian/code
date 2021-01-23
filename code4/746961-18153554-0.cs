    using (fs =new FileStream(NewFileName, FileExists ? FileMode.Append : FileMode.Create)) {
        sw = new StreamWriter(fs);
        MessageBox.Show(Record);
        sw.WriteLine(Record);
        fs.Close();
    }
