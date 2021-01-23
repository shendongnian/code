    //
    //some example class
    //
    public class Music: IComparable<Music>
    {
        public Music() { }
        public string Author { get; set; }
        public string Name { get; set; }
        public int CompareTo(Music other)
        {
            if (Author == other.Author)
            {
                return Name.ToUpper().CompareTo(other.Name.ToUpper());
            }
            else
            {
                return Author.ToUpper().CompareTo(other.Author.ToUpper());
            }
        }
    }
    //
    // that is to deserialize
    //
    var musics = new SortedSet<Music>();
    var mPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\j.txt";
    if (File.Exists(mPath))
    {
        File.Copy(mPath, mPath.Replace(".txt", DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ".txt"));
        var ser = new XmlSerializer(typeof(List<Music>));
        using (var sr = new StreamReader(mPath))
        {
            musics = new SortedSet<Music>((List<Music>)ser.Deserialize(sr));
        }
    }
    //
    // that is to serialize
    //
    var ser = new XmlSerializer(typeof(List<Music>));
    using (var wri = new StreamWriter(mPath))
    {
        ser.Serialize(wri, musics.ToList());
    }
