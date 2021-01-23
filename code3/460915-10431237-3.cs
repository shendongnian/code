    if(savefile1.ShowDialog() == DialogResult.OK)
    {
            Values v = new Values();
            v.task1_name = this.task1_name.Text;
            v.task1_desc = this.task1_desc.Text;
            v.task1_date = this.task1_date.Value;
            v.task1_time = this.task1_time.Value;
            SaveValues(savefile1.FileName, v);
    }
 -
    public void SaveValues(string fileName, Values v)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Values));
        using(TextWriter textWriter = new StreamWriter(fileName))
        {
            serializer.Serialize(textWriter, v);
            textWriter.close();
        }
    ...
    }
