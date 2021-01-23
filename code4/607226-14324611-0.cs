    public class DocLib
            {
                public string Title { get; set; }
                public string spriteCssClass { get { return "rootfolder"; } }
    
                public DocLib()
                {
                    items = new List<DocLib>();
                }
    
                public List<DocLib> items { get; set; }
    
            }
