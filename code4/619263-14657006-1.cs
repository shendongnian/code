    // Prerequisites to run:
    //      1)  Project, Add Reference, .NET, "System.Windows.Forms"
    
    public interface IPlugIn
    {
        void StartPlugIn(Form mainForm);
    }
    public interface IPlugInMetadata
    {
        string PlugInTitle { get; }
        string PlugInDescription { get; }
        string PlugInVersion { get; }
    }
