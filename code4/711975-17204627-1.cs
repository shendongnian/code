     public interface ISource
    {
        string ConfigPath { get; }
        string AvailVersion { get; }
        IDictionary<string, string> AvailFiles { get; }
    }
    public class Source : BaseClass, ISource
    {
        public Source()
        {
            ConfigPath = @"D:\Mindful\Visual Studio 2012\Projects\AutoUpdator\AutoUpdator\Source\AvailInfoFile.config";
        }
        
        public string AvailVersion
        {
            get
            {
                return Version;
            }
        }
        public IDictionary<string, string> AvailFiles
        {
            get
            {
                return Files;
            }
        }
    }
