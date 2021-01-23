    public interface IAudio { /* .. as above .. */ }
    public abstract class CAUdio : IAudio
    {
         // provide boiler-plate functionality
         public virtual string GetDetails() { /* ... */ }
    }
    public class CMusic : CAudio
    {
         public override string GetDetails() { /* .. specialise */ }
    }
