    public struct CapInfo
    {
        public readonly int Packets;
        public readonly string Duration;
        CapInfo(int packets, string duration)
        {
            this.Packets=packets;
            this.Duration=duration;
        }
        public static CapInfo ReadFileDetails(string file)
        {
            using(var fs=System.IO.File.Open(file, System.IO.FileMode.Open, System.IO.FileAccess.Read))
            {                
                int packets = // from the file
                string duration = // from the file
                return new CapInfo(packets, duration);
            }
            
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var info=CapInfo.ReadFileDetails(file);
        }
    }
