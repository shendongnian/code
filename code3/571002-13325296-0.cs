        static void Main(string[] args)
        {
            List<string> search = searchSong("SomeThing");
            foreach (string song in search)
            {
                Console.Writeline(song);
            }
        }
        public List<string> searchSong(string value)
        {
            List<string> songs = new List<string>();
            String[] mp3 = null;
            mp3 = Directory.GetFiles(@"D:\Songs", "*.mp3", SearchOption.AllDirectories).ToArray();
            foreach (String item in mp3)
            {
                if (item.Contains(value))
                {
                    songs.Add(item);
                }
            }
            return songs;
        }
    }
