    var root = XDocument.Parse(@"<data>
    <num>3</num>
    <str>string</str>
    <boo>true</boo>
    <point x=""3"" y=""5"" />
    </data>").Root;
    
    public class MyObject()
    {
      public class Point 
      {
        int X {get;set;}
        int Y  {get;set;}
      }
    
      public MyObject() {
       Point = new Point();
      }
      public int Num {get;set;}
      public string Str {get;set;}
      public bool Boo {get;set;}
      public Point Point {get; private set;}
    }
    
    var myObj = root.Select(new MyObject {
                                              Num = int.Parse(root.Element("num").Value),
                                              Str = root.Element("str").Value,
                                              Boo = bool.Parse(root.Element("boo").Value),
                                              Point.X = int.Parse(root.Element("point").Attribute("x").Value),
                                              Point.Y = int.Parse(root.Element("point").Attribute("y").Value)
                                         });
