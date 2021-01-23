    public class DocLib{
       public string Title { get; set; }
       public string spriteCssClass { get { return "rootfolder"; } }
        
       List<DocLib> _items;
    
       public DocLib(){
          _items = new List<DocLib>();
       }
        
       public List<DocLib> Items { 
          get{
             return _items;
          }
       }
    }
