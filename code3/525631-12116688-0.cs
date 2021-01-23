    var ser = new XmlSerializer(typeof(saveData));
    var obj = (saveData)ser.Deserialize(stream);
    public class saveData
    {
        public string strFolder1;
        public string strFolder2;
        public string strTabName;
        public string strTabText;
    }
