    void btnLoadGame_Click(object sender, EventArgs e)
    {
        Stream stream = File.Open("SaveGame.osl", FileMode.Open);
        BinaryFormatter bformatter = new BinaryFormatter();
        SaveLoad load = (SaveLoad)bformatter.Deserialize(stream);
        // ***********************************
        FormMain.AdventurerManager.AdventurerList = SaveLoad.Adventurers
        // ***********************************
        stream.Close();
        Date.CalculateDate();
        this.Visible = false;
        ((FormMain)(this.ParentForm)).ControlMainScreen.Visible = true;
    }
