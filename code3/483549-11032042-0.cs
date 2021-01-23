    public class Timer1        
    {
    System.Timers.Timer aTimer = new System.Timers.Timer();
    public static void Main()
    {
        Timer1 tTimer = new Timer1();//<-this line right here is killing you 
                                     //remove it, as I don't see anyuse for it at all
