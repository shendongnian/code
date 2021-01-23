    [Serializable()]
    public class SaveLoad : ISerializable
    {
        public string GameDay = null;
        public List<Adventurer> Adventurers = null; 
            //FormMain.AdventurerManager.AdventurerList;
        public SaveLoad()
        {
            GameDay = "Date";
            Adventurers = new List<Adventurer>() { new Adventurer { Name = "a1", Type = "t1" }, new Adventurer { Name = "a1", Type = "t1" } }; ;
        }
        public SaveLoad(SerializationInfo info, StreamingContext ctxt)
        {
            GameDay = (string)info.GetValue("Date", typeof(string));
            Adventurers = (List<Adventurer>)info.GetValue("Adventurers", typeof(List<Adventurer>));
        }
        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("Date", GameDay);
            info.AddValue("Adventurers", Adventurers);
        }
    }
    [Serializable()]
    public class Adventurer
    {
        public string Name { get; set; }
        public string Type { get; set; }
    }
    private void btnLoadGame_Click(object sender, EventArgs e)
        {
            SaveLoad sl = new SaveLoad();
            Stream stream = File.Open("SaveGame.osl", FileMode.Open);
            BinaryFormatter bformatter = new BinaryFormatter();
            sl = (SaveLoad)bformatter.Deserialize(stream);
            stream.Close();
            MessageBox.Show(sl.Adventurers.Count.ToString());
            //Date.CalculateDate();
            //this.Visible = false;
            //((Form1)(this.ParentForm)).ControlMainScreen.Visible = true;
        }
        private void btnSaveGame_Click(object sender, EventArgs e)
        {
            SaveLoad sl = new SaveLoad();
            
            Stream stream = File.Open("SaveGame.osl", FileMode.Create);
            BinaryFormatter bformatter = new BinaryFormatter();
            bformatter.Serialize(stream, sl);
            stream.Close();
        }
