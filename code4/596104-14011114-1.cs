    private static void GenerateMusicFileDict()
    {
         List<StorageFile> music_file_list = MusicFileDict.GetMusicList(); 
         for (int i = 0; i < music_file_list.Count; i++)
         {
              StorageFile currentFile = music_file_list[i];
              _data.Add(new MusicFileDict 
                        { 
                            Id = i,
                            MusicFileUri = new Uri(currentFile.Path)
                        });          
         } 
    }
