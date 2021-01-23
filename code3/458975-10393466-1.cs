    public void SomeMethod()
    {
        Values v = LoadValues();
        this.task1_name.Text = v.task1_name;
        this.task1_desc.Text = v.task1_desc;
        this.task1_date.Value = v.task1_date;
        this.task1_time.Value = v.task1_time;
    }
    public Values LoadValues()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Values));
        using (TextReader textReader = new StreamReader(@"E:\TheFile.xml"))
        {
            return (Values)serializer.Deserialize(textReader);
        }
    }
