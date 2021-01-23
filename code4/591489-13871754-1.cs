     public static async Task<string> PingAsync(MyType1 var1, MyType2 var2)
     {
       using (var client = new WebClient())
       {
         var stringResult = client.DownloadStringTaskAsync(..);
         return JSON.Parse(stringResult).Whatever;
       }
     }
