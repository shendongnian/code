    public interface ITarget
    {
        string LocalConfigPath { get; }
    
        string LocalVersion { get; }
    
        IDictionary<string, string> LocalFiles { get; }
    }
    
    public interface ISource
    {
        string AvailConfigPath { get; }
    
        string AvailVersion { get; }
    
        IDictionary<string, string> AvailFiles { get; }
    }
    
    internal abstract class BaseClass
    {
        public virtual string ConfigPath
        {
            get;
        }
    
        private XDocument document = XDocument.Load(ConfigPath);
    
        public string Version
        {
            get
            {
                return document.Root
                         .Element("InfoConfigFile")
                         .Attribute("version").Value;
            }
        }
    
        public IDictionary<string, string> Files
        {
            get
            {
                return document.Root
                         .Element("files")
                         .Elements("file")
                         .ToDictionary(x => x.Attribute("name").Value,
                                       x => x.Attribute("version").Value);
            }
        }
    }
    
    
    internal class Target : BaseClass, ITarget
    {
        public override string LocalConfigPath
        {
            get
            {
                return @"D:\Mindful\Visual Studio 2012\Projects\AutoUpdator\AutoUpdator\Target\LocalInfoFile.config";
            }
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
    
    public class Source : BaseClass, ISource
    {
        public override string AvailConfigPath
        {
            get
            {
                return @"D:\Mindful\Visual Studio 2012\Projects\AutoUpdator\AutoUpdator\Source\AvailInfoFile.config";
            }
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
