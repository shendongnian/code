    static ColumnReader GetColumnReader(string filename){
       return () => {
         using (TextReader reader = new StreamReader(filename)){
            var headers = reader.ReadLine();
            return reader.ReadLine();
         }
      }
    }
