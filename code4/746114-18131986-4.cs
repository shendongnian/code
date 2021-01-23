    namespace String1byte
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                String8bit s1 = new String8bit("cat");
                String8bit s2 = new String8bit("cat");
                String8bit s3 = new String8bit("\xFD\x0B\x16MBEPEXE1.");
                HashSet<String8bit> hs = new HashSet<String8bit>();
                hs.Add(s1);
                hs.Add(s2);
                hs.Add(s3);
                System.Diagnostics.Debug.WriteLine(hs.Count.ToString());
                System.Diagnostics.Debug.WriteLine(s1.Value + " " + s1.GetHashCode().ToString());
                System.Diagnostics.Debug.WriteLine(s2.Value + " " + s2.GetHashCode().ToString());
                System.Diagnostics.Debug.WriteLine(s3.Value + " " + s3.GetHashCode().ToString());
                System.Diagnostics.Debug.WriteLine(s1.Equals(s2).ToString());
                System.Diagnostics.Debug.WriteLine(s1.Equals(s3).ToString());
                System.Diagnostics.Debug.WriteLine(s1.MatchStart("ca").ToString());
                System.Diagnostics.Debug.WriteLine(s3.MatchStart("ca").ToString());
            }
        }
    
        public struct String8bit
        {
            private static Encoding EncodingUnicode = Encoding.Unicode;
            private static Encoding EncodingWin1252 = System.Text.Encoding.GetEncoding("Windows-1252");
            private byte[] bytes;
            public override bool Equals(Object obj)
            {
                // Check for null values and compare run-time types.
                if (obj == null) return false;
                if (!(obj is String8bit)) return false;
                String8bit comp = (String8bit)obj;
                if (comp.Bytes.Length != this.Bytes.Length) return false;
                for (Int32 i = 0; i < comp.Bytes.Length; i++)
                {
                    if (comp.Bytes[i] != this.Bytes[i])
                        return false;
                }
                return true;
            }
            public override int GetHashCode()
            {
                UInt32 hash = (UInt32)(Bytes[0]); 
                for (Int32 i = 1; i < Bytes.Length; i++) hash = hash ^ (UInt32)(Bytes[0] << (i%4)*8);
                return (Int32)hash;
            }
            public bool MatchStart(string start)
            {
                if (string.IsNullOrEmpty(start)) return false;
                if (start.Length > this.Length) return false;
                start = start.ToLowerInvariant();   // SQL is case insensitive
                // Convert the string into a byte array
                byte[] unicodeBytes = EncodingUnicode.GetBytes(start);
                // Perform the conversion from one encoding to the other 
                byte[] win1252Bytes = Encoding.Convert(EncodingUnicode, EncodingWin1252, unicodeBytes);
                for (Int32 i = 0; i < win1252Bytes.Length; i++) if (Bytes[i] != win1252Bytes[i]) return false;
                return true;
            }
            public byte[] Bytes { get { return bytes; } }
            public String Value { get { return EncodingWin1252.GetString(Bytes); } }
            public Int32 Length { get { return Bytes.Count(); } }
            public String8bit(string word)
            {
                word = word.ToLowerInvariant();     // SQL is case insensitive
                // Convert the string into a byte array 
                byte[] unicodeBytes = EncodingUnicode.GetBytes(word);
                // Perform the conversion from one encoding to the other 
                bytes = Encoding.Convert(EncodingUnicode, EncodingWin1252, unicodeBytes);
            }
            public String8bit(Byte[] win1252bytes)
            {   // if reading from SQL char then read as System.Data.SqlTypes.SqlBytes
                bytes = win1252bytes;
            }
        }
    }
