    public class Play {
    
        delegate string ColumnReader();
    
        static ColumnReader GetColumnReader(string filename) {
            return () => {
                using (TextReader reader = new StreamReader(filename)) {
                    var headers = reader.ReadLine();
                    return reader.ReadLine();
                }
            };
        }
    
        public static void Main(string[] args) {
            var Reader = GetColumnReader("Input.tsv");
            Console.WriteLine(Reader());
        }
    
    
    }
