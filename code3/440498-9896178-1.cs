    public class ΦΑΡΜΑΚΑ
    {
        public string A;
        public string ΦΑΡΜ_ΑΓΩΓΗ;
        public string ΧΟΡΗΓΗΣΗ;
        public string ΛΗΞΗΣ;
        public string ΑMKA;
    }
    XmlSerializer xml = new XmlSerializer(typeof(ΦΑΡΜΑΚΑ[]),new XmlRootAttribute("dataroot"));
            
    ΦΑΡΜΑΚΑ[] array = (ΦΑΡΜΑΚΑ[])xml.Deserialize(File.Open(@"D:\Downloads\bio3.xml", FileMode.Open));
    richTextBox1.Text = String.Join(Environment.NewLine, array.Select(x => x.ΦΑΡΜ_ΑΓΩΓΗ));
