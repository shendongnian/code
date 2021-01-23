    public class Color{
    
    public int R{
        get;
        set; 
        }
   
    
    public int G{
        get;
        set; 
        }
    
    public int B{
        get;
        set; 
        }
    
    public Color(string mixedRGB, string order){
        R = Int32.Parse(mixedRGB.Substring(order.IndexOf('R'),3));
        G = Int32.Parse(mixedRGB.Substring(order.IndexOf('G'),3));
        B= Int32.Parse(mixedRGB.Substring(order.IndexOf('B'),3));
    }
