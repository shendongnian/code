    public class Nokta
    {
        public Point point;
        public Color renk;        
    }
    deniz=noktalar.FindAll(FindDeniz);
    private static bool FindDeniz(Nokta n)
    {
        if (n.renk.Name == "ff000080")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
