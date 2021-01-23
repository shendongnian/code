    [Serializable]
    public class SaveIt
    {
        public string Text1 {get; set;}
        public string Text2 {get; set;}
        ...
    }
    private void Save(string filename)
    {
        SaveIt save = new SaveIt();
        save.Text1 = textBox1.Text;
        ...
        using(Stream stream = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.Write))
        {
            XmlSerializer xmlserializer = new XmlSerializer( typeof(SaveIt) );
            xmlserializer.Serialize( stream, save );
        }
    }
    private void Load(string filename)
    {
        SaveIt load;
        using(Stream stream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read))
        {
            XmlSerializer xmlserializer = new XmlSerializer( typeof(SaveIt) );
            load = xmlserializer.Deserialize(stream) as SaveIt;
        }
        textBox1.Text = load.Text1;
        textBox2.Text = load.Text2;
        ...
    }
