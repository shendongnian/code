    pulbic interface IPlugin
    {
        double Calculate(double d1, double d2);
    }
    
    public class WebConnectPlugin: IPlugin
    {
       public double Calculate(double d1, double d2){ // some code}
    }
    public class DBConnectPlugin: IPlugin
    {
       public double Calculate(double d1, double d2){ // some code}
    }
