     public static Stream GetResourceContent(string rName){
         string resName = System.Reflection.Assembly
             .GetExecutingAssembly().GetManifestResourceNames()
             .FirstOrDefault(rn => rn.EndsWith("."+rName));
        if(resName!=null)
            return System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(resName);
        else
            return null;
    }
