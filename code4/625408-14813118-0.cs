    public class Globals    
    {
        public static Rotor_Calc Rotor;
    
         public static double EffHot
         {
             get { return Convert.ToDouble(Rotor.EffHot); }
             set { Rotor.EffHot = value.ToString(); }
         }
    
         public static double EffCold
         {
             get { return Convert.ToDouble(Rotor.EffCold); }
             set { Rotor.EffCold = value.ToString(); }
         }
    }
