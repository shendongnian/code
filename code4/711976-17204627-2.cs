    public interface ITarget
    {
        string ConfigPath { get; }
        string LocalVersion { get; }
        IDictionary<string, string> LocalFiles { get; }
    }
    internal class Target : BaseClass, ITarget
    {
        public Target()
        {
            ConfigPath = @"D:\Mindful\Visual Studio 2012\Projects\AutoUpdator\AutoUpdator\Target\LocalInfoFile.config";
        }
        public string LocalVersion
        {
            get
            {
                return Version;
            }
        }
        public IDictionary<string, string> LocalFiles
        {
            get
            {
                return Files;
            }
        }
    }
