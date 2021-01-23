    public string getWebsite( string Url )
      {
         Stopwatch stopwatch = Stopwatch.StartNew();
         HttpWebRequest http = (HttpWebRequest) WebRequest.Create( Url );
         http.Headers.Add( HttpRequestHeader.AcceptEncoding, "gzip,deflate" );
         string html = string.Empty;
         using ( HttpWebResponse webResponse = (HttpWebResponse) http.GetResponse() )
         {
            using ( Stream responseStream = webResponse.GetResponseStream() )
            {
               Stream decompressedStream = null;
               if ( webResponse.ContentEncoding.ToLower().Contains( "gzip" ) )
                  decompressedStream = new GZipStream( responseStream, CompressionMode.Decompress );
               else if ( webResponse.ContentEncoding.ToLower().Contains( "deflate" ) )
                  decompressedStream = new DeflateStream( responseStream, CompressionMode.Decompress );
               if ( decompressedStream != null )
               {
                  using ( StreamReader reader = new StreamReader( decompressedStream, Encoding.Default ) )
                  {
                     html = reader.ReadToEnd();
                  }
                  decompressedStream.Dispose();
               }
            }
         }
         Debug.WriteLine( stopwatch.ElapsedMilliseconds );
         return html;
      }
