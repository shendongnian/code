    private void LoadPlayListFromIsolatedStorage(BackgroundAudioPlayer player)
        {
            // clear previous playlist
            _playList.Clear();
            // access to isolated storage
            IsolatedStorageFile isoStore = IsolatedStorageFile.GetUserStoreForApplication();
            using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream("AlbumsData.dat", FileMode.OpenOrCreate, isoStore))
            {
                if (stream.Length > 0)
                {
                    DataContractSerializer serializer = new DataContractSerializer(typeof(List<Album>));
                    List<Album> strm = serializer.ReadObject(stream) as List<Album>;
                    List<Song> _songs = strm[0].Songs;
                    for (int i = 0; i < _songs.Count; i++)
                    {
                        AudioTrack audioTrack = new AudioTrack(
                                new Uri(_songs[i].Directory, UriKind.Absolute), // URL
                                _songs[i].Title,         // MP3 Music Title
                                "Artist",        // MP3 Music Artist
                                "Album",         // MP3 Music Album name
                                new Uri(_songs[i].AlbumArt, UriKind.Absolute)    // MP3 Music Artwork URL
                                );
                        _playList.Add(audioTrack);
                    }
                }
                else
                {
                    // no AudioTracks from Isolated Storage
                }
                // start playing
                PlayTrack(player);
            }
 
