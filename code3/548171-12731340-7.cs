     public class MyReader
     {
          private IStreamFilter _streamFilter;
           
          public MyReader(IStreamFilter streamFilter)
          {
               this._streamFilter = streamFilter;
          }
          public string ReadString()
          { 
              var readString = reader.GetString(x => x.Contains(this._streamFilter.Delimiter);
               // apply the filter for reading string
          }
     }   
