    class A
    {
         List<string> songs=new List<string>();
         public IEnumerable<string> Songs { get{ return songs;}}
         public void Add(string song)
         {
             songs.Add(song);
         }
    }
