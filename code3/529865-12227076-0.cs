     using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(dllName)) 
     {
         if (stream != null)
         {
             byte[] data = new byte[stream.Length];
             stream.Read(data, 0, data.Length);
             return Assembly.Load(data);
         }
     }
 
