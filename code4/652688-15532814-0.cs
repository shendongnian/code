    using (StreamWriter writer = new StreamWriter(filePath))
    {
            for (int i = 0; i < MusicList.Count; i++)
            {
                writer.WriteLine(MusicList[i].songName + " , " + MusicList[i].artistName);
            }
    }
