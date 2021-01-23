     public class MyReader
     {
          private IStreamFilter _streamFilter;
           
          public MyReader(IStreamFilter streamFilter)
          {
               this._streamFilter = streamFilter;
          }
          public string ReadString()
          { 
               var currentFilterSettings = this._streamFilter.GetFilter();
               var readString = reader.GetString(x => x.Contains(currentFilterSettings .Delimiter);
               // apply the filter for reading string
          }
     }   
