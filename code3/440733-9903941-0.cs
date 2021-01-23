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
            // find files bigger than (roughly) 1GB
            var BigFiles = from f in f_results.FromFile(@"C:\SomeFile.dat")
                           where f.size > 1e9
                           select f;
        }
    }
