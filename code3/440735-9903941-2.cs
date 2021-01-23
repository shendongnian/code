    public class f_results {
        public String name { get; set; }
        public DateTime cdate { get; set; }
        public DateTime mdate { get; set; }
        public DateTime adate { get; set; }
        public Int64 size { get; set; }
        // write one to a file
        public void WriteTo(BinaryWriter wrtr) {
            wrtr.Write(name);
            wrtr.Write(cdate.Ticks);
            wrtr.Write(mdate.Ticks);
            wrtr.Write(adate.Ticks);
            wrtr.Write(size);
        }
        // read one from a file
        public f_results(BinaryReader rdr) {
            name = rdr.ReadString();
            cdate = new DateTime(rdr.ReadInt64());
            mdate = new DateTime(rdr.ReadInt64());
            adate = new DateTime(rdr.ReadInt64());
            size = rdr.ReadInt64();
        }
        // stream a whole file as an IEnumerable (so very little memory needed)
        public static IEnumerable<f_results> FromFile(string dataFilePath) {
            var file = new FileStream(dataFilePath, FileMode.Open);
            var rdr = new BinaryReader(file);
            var eos = rdr.BaseStream.Length;
            while (rdr.BaseStream.Position < eos) yield return new f_results(rdr);
            rdr.Close();
            file.Close();
        }
    }
    
    class Program {
        static void Main(string[] args) {
            var d1 = new DirTree(@"C:\",
                new DirTree(@"C:\Dir1",
                    new DirTree(@"C:\Dir1\Dir2"),
                    new DirTree(@"C:\Dir1\Dir3")
                    ),
                    new DirTree(@"C:\Dir4",
                    new DirTree(@"C:\Dir4\Dir5"),
                    new DirTree(@"C:\Dir4\Dir6")
                    ));
            var path = @"D:\Dirs.dir";
            // write the directory tree to a file
            var file = new FileStream(path, FileMode.CreateNew | FileMode.Truncate);
            var w = new BinaryWriter(file);
            d1.WriteTo(w);
            w.Close();
            file.Close();
            // read it from the file
            var file2 = new FileStream(path, FileMode.Open);
            var rdr = new BinaryReader(file2);
            var d2 = new DirTree(rdr);
            // now inspect d2 in debugger to see that it was read back into memory
            // find files bigger than (roughly) 1GB
            var BigFiles = from f in f_results.FromFile(@"C:\SomeFile.dat")
                           where f.size > 1e9
                           select f;
        }
    }
    class DirTree {
        public string Path { get; private set; }
        private string FilesFile { get { return Path.Replace(':', '_').Replace('\\', '_') + ".dat"; } }
        
        public IEnumerable<f_results> Files() {
            return f_results.FromFile(this.FilesFile);
        }
        // you'll want to encapsulate this in real code but I didn't for brevity
        public DirTree[] _SubDirectories;
       
        public DirTree(BinaryReader rdr) {
            Path = rdr.ReadString();
            int count = rdr.ReadInt32();
            _SubDirectories = new DirTree[count];
            for (int i = 0; i < count; i++) _SubDirectories[i] = new DirTree(rdr);
        }
        public DirTree( string Path, params DirTree[] subDirs){
            this.Path = Path;
            _SubDirectories = subDirs;
        }
        public void WriteTo(BinaryWriter w) {
            w.Write(Path);           
            w.Write(_SubDirectories.Length);
            // depth first is the easiest way to do this
            foreach (var f in _SubDirectories) f.WriteTo(w);
        }
    }
}
