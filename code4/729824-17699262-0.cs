    public interface IAssemblyHelper
    {
        string GetLocationOfExecutingAssembly();
    }
    public class AssemblyHelper : IAssemblyHelper
    {
        public string GetLocationOfExecutingAssembly()
        {
            return Assembly.GetExecutingAssembly().Location;
        }
    }
