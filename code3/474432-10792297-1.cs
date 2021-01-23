    public interface IKillable
    {  }
    public static class KillableExtensions
    {
        public static void Kill(this IKillable form)
        {
            ...
        }
    }
