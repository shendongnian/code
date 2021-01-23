    #if !XDPL22
    namespace ParserXPDL21
    #else
    namespace ParserXPDL22
    #endif
    {
        [Serializable]
        public class Root
        {
    #if !XDPL22
            public Artifact[] Artifacts { get; set; }
    #endif
            public int NormalProperty1 { get; set; }
            public int NormalProperty2 { get; set; }
            public int NormalProperty3 { get; set; }
    
        }
    }
