    namespace ReallyCoolProject
    {
        public class MyCoolResolver : XmlUrlResolver
        {
             public override object GetEntity(Uri absoluteUri, string role, Type ofObjectToReturn)
             {
                string binDirectory =               Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
                binDirectory = binDirectory + "/mods";
    
                if (absoluteUri.OriginalString.Contains("-//W3C//DTD SVG 1.1//EN"))
                {
                    return File.Open(binDirectory + "/svg11.dtd", FileMode.Open);
                }
    
                if (absoluteUri.OriginalString.Contains("-//W3C//ENTITIES SVG 1.1 Document Model//EN"))
                {
                    return File.Open(binDirectory + "/svg11-model.mod", FileMode.Open);
    	    }
    			
    	    //.....many many more mod files than this
    			
    	 }
        }
    }
