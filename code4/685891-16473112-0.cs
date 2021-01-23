    void btnLoadGame_Click(object sender, EventArgs e)
    {
        Stream stream = File.Open("SaveGame.osl", FileMode.Open);
        BinaryFormatter bformatter = new BinaryFormatter();
        // ***********************************
        FormMain.AdventurerManager.AdventurerList = (SaveLoad)bformatter.Deserialize(stream);
        // ***********************************
        stream.Close();
        Date.CalculateDate();
        this.Visible = false;
        ((FormMain)(this.ParentForm)).ControlMainScreen.Visible = true;
    }
