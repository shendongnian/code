     [Serializable]   
     public class Files
        {
            public Files(){}
        
            [XmlAttribute()]
            public bool Upload{get;set;}
        
            public List<InputFile> InputFiles
               {
               get{retrun inputFiles;}
               set{inputFiles=value;}
               }
            List<InputFile> inputFiles = new List<InputFile>();
        
            public List<OutputFile > OutputFiles
               {
               get{return outputFiles ;}
               set{outputFiles =value;}
               }
            List<OutputFile > outputFiles = new List<OutputFile >();
        }
