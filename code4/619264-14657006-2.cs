        // Prerequisites to run:
    //      1)  Project, Add Reference, Projects, "ContractInterface"
    //      2)  Project, Add Reference, .NET, "System.Windows.Forms"
    //      3)  Project, Add Reference, .NET, "System.ComponentModel.Composition"
    //      4)  Project, Properties, Build Events, Post-Build event command line:
    //          xcopy "$(ProjectDir)$(OutDir)$(TargetFileName)"  "$(SolutionDir)Plug-Ins\" /Y
    //      5)  Project, Properties, Build Events, Run the post-build event:, Always
    //      6)  Project, Properties, Application, Icon and manifest, [Select an icon]
    [Export(typeof(IPlugIn))]
    [PluginMetadata]
    public class Program : IPlugIn
    {
        private Form MainForm;
        public void StartPlugIn(Form mainForm)
        {
            MainForm = mainForm;
            // Place a TextBox on the Main Form
            TextBox textBox = new TextBox();
            textBox.Text = "PlugInA";
            MainForm.Controls.Add(textBox);
            textBox.Width = 65;
            textBox.Height = 20;
            textBox.Top = 0;
            textBox.Left = 0;
        }
    }
    // Create a custom strong-typed Metadata Attribute for MEF
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class PluginMetadataAttribute : ExportAttribute
    {
        public string PlugInTitle { get; set; }
        public string PlugInDescription { get; set; }
        public object PlugInVersion { get; set; }
        public PluginMetadataAttribute()
            : base(typeof(IPlugInMetadata))
        {
            PlugInTitle = "Plug-In A";
            PlugInDescription = "This is Plug-In A";
            PlugInVersion = "1.0.0.0";
        }
    }
