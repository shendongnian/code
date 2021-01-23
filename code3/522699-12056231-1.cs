    public class ParentCanvasTemplate
        {
            public ParentCanvasTemplate(string headername)
            {
                if (headername == "Squares")
                {
                    HeaderName = headername;
                    ListTemplates = new List<CanvasTemplate>();
                    CanvasTemplate ct = new CanvasTemplate("Smaller Square", 400, 400);
                    ListTemplates.Add(ct);
                    ct = new CanvasTemplate("Bigger Square", 800, 800);
                    ListTemplates.Add(ct);
                }
                else if (headername == "Rectangles")
                {
                    HeaderName = headername;
                    ListTemplates = new List<CanvasTemplate>();
                    CanvasTemplate ct = new CanvasTemplate("Smaller Rectangle", 600, 400);
                    ListTemplates.Add(ct);
                    ct = new CanvasTemplate("Bigger Rectangle", 800, 600);
                    ListTemplates.Add(ct);
                }
            }
            public string HeaderName { get; set; }
            public List<CanvasTemplate> ListTemplates { get; set; }
        }
    
        public class CanvasTemplate
        {
            
    
            public CanvasTemplate(string name, double width, double height)
            {       
    
                Name = name;
                Width = width;
                Height = height;
    
            }
    
    
            public string Name { get; set; }
            public double Width { get; set; }
            public double Height { get; set; }
    
    
        }  
