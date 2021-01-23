     static IEnumerable<string> GetColumnReader(string filename) {
       using (TextReader reader = new StreamReader("aa")) {
         var headers = reader.ReadLine();
         yield return reader.ReadLine();
       }
     }
