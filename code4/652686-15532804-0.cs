    StreamWriter FileSaving = new StreamWriter("MusicList");
    for (int i = 0; i < MusicList.Count; i++)
    {
        string sName = MusicList[i].songName;
        string aName = MusicList[i].artistName;
    }
    FileSaving.Close();
