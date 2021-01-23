    void Main()
    {
        Profile p = new Profile("bob", @"c:\foo");
        p.FileList.Add("bar.txt");
        
        Profile copy = p.DeepCopy();
        copy.FileList.Clear();
        copy.FileList.Add("baz.log");
        
        p.Dump("p");
        copy.Dump("copy");
    }
    public class Profile
    {
        public Profile(string name, string targetPath)
        {
            this.Name = name;
            this.TargetPath = targetPath;
            this.FileList = new List<string>();
        }
        
        public Profile DeepCopy()
        {
            Profile copy = (Profile)this.MemberwiseClone(); // this takes care of Name & TargetPath
            copy.FileList = new List<string>(this.FileList);
            return copy;
        }
        
        public string Name { get; private set; }
        public string TargetPath { get; private set; }
        public List<string> FileList { get; private set; }
    }
