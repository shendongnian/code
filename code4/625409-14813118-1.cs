    public class Globals    
    {
        public static double EffHot;
        public static double EffCold;
        public static Rotor_Calc Rotor
        {
            set 
            {
                EffHot = Convert.ToDouble(Rotor.EffHot);
                EffCold = Convert.ToDouble(Rotor.EffCold);
            }
         }
    
    }
