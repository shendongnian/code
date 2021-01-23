    interface IUIConcernExtension
    {
        string Name { get; }
    }
    public interface IUIConcern<out T> where T : IUIConcernExtension
    {
        Func<T> Extend();
    }
    public class UIConcern<T> where T : IUIConcernExtension
    {
        private static List<IUIConcern<T>> _Concerns = new List<IUIConcern<T>>();
        public static void Register(string concernName, IUIConcern<T> uiConcern) 
        {
            Concerns.Add(uiConcern);
        }
        public static List<IUIConcern<T>> Concerns
        {
            get { return _Concerns; }
            set { _Concerns = value; }
        }
    }
