    public class SVGElement
    {
      public String id {set; get;}
      public String style {set; get;}
    }
    
    [XMLTypeOf("svg")]
    public class SVG : public SVGElement
    {
        public GraphicGroup g {set; get;}
    }
    
    [XMLTypeOf("g")]
    public class GraphicGroup : public SVGElement
    {
       public GraphicGroup g {set; get;}
       public Circle circle { set; get;}
       public Rectangle rectangle { set; get;}
    }
    
    [XMLTypeOf("circle")]
    public class Circle : public SVGElement { ... }
    
    [XMLTypeOf("rectangle")]
    public class Rectangle : public SVGElement { ... }
