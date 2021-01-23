    public sealed class ThankYou {
       private ThankYou() { }
       private readonly static ThankYou bye = new ThankYou();
       public static ThankYou Bye { get { return bye; } }
    }
