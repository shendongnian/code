        static void Main(string[] args) {
            string someText = char.ConvertFromUtf32(0x1D7D9);
            using (var stream = new MemoryStream()) {
                using (var writer = new StreamWriter(stream, Encoding.UTF32)) {
                    writer.Write(someText);
                    writer.Flush();
                }
                var bytes = stream.ToArray();
                foreach (var oneByte in bytes) {
                    Console.WriteLine(oneByte.ToString("x"));
                }
            }
        }
