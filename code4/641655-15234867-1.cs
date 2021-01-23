      string fileName = @"c:\myfile.csv.gz";
      using (var fileStream = File.OpenRead(fileName))
      {
          using (GZipStream gzipStream = new GZipStream(fileStream, CompressionMode.Decompress, false))
          {
              using (TextReader textReader = new StreamReader(gzipStream))
              {
                var engine = new FileHelperAsyncEngine<CSVItem>();
                using(engine.BeginReadStream(textReader))
                {
                    foreach(var record in engine)
                    {
                       // Work with each item
                    }
                }
              }
          }
      }
