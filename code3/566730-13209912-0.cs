    public void ReadHighScore()
    {
        using (var store = IsolatedStorageFile.GetUserStoreForApplication())
        {
            using (var stream = new IsolatedStorageFileStream("highscore.txt", System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Read, store))
            {
                using (var reader = new BinaryReader(stream))
                {
                    highScore.score = reader.ReadInt32();
                }
            }
        }
    }
    public void SaveHighScore()
    {
        using (var store = IsolatedStorageFile.GetUserStoreForApplication())
        {
            using (var stream = new IsolatedStorageFileStream("highscore.txt", System.IO.FileMode.Create, System.IO.FileAccess.ReadWrite, store))
            {
                using (var writer = new BinaryWriter(stream))
                {
                    writer.Write(highScore.score);
                }
            }
        }
    }
