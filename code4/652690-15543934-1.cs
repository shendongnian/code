        public void Registry()
        {
            List<Name> MusicList = new List<Name>();
            MusicList.Add(new Name(SongName = txtSongName.Text , ArtistName = txtArtistName.Text)); //Add new elements to the NameClass
            Serializer<List<Name>>.Serialize(@"C:\saved.xml", MusicList);
        }
