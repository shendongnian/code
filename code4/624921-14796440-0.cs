    public class ReadResource
    {
        public string ReadInEmbeddedFile (string filename) {
            // assuming this class is in the same assembly as the resource folder
            var assembly = typeof(ReadResource).Assembly;
            // get the list of all embedded files as string array
            string[] res = assembly.GetManifestResourceNames ();
            var file = res.Where (r => r.EndsWith(filename)).FirstOrDefault ();
            var stream = assembly.GetManifestResourceStream (file);
            string file_content = new StreamReader(stream).ReadToEnd ();
            
            return file_content;
         }
    }
