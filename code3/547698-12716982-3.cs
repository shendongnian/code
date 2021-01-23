    //In a 2nd project that compiles as a DLL
    public interface IMyPlugin
    {
        Control GetControl();
    }
    
    ///////////////////
    
    //In your main project
    private List<IMyPlugin> pluginsList;   
    
    private void MainForm_Load(object sender, EventArgs e)
    { 
        foreach(string pluginPath in Directory.EnumerateFiles(Application.StartupPath + @"\Plugins\", "*.dll"))
        {
            try
            {
                //load the assembly
                Assembly pluginAssembly = Assembly.LoadFrom(pluginPath);
                //Find all types defined in the assembly.
                Type[] types = pluginAssembly.GetTypes();
                //Filter the types to only ones that implment IMyPlugin
                var plugins = types.Where(x => typeof(IMyPlugin).IsAssignableFrom(x));
                //Filter the plugins to only ones that are createable by Activator.CreateInstance
                var constructablePlugins = plugins.Where(x => !x.ContainsGenericParameters && x.GetConstructor(Type.EmptyTypes) != null);
                foreach (var pluginType in constructablePlugins)
                {
                    //instantiate the object
                    IMyPlugin plugin = (IMyPlugin)Activator.CreateInstance(pluginType);
                    pluginsList.Add(plugin);
                }
            }
            catch (BadImageFormatException ex)
            {
                //ignore this exception -- probably a runtime DLL required by one of the plugins..
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "MainForm.MainForm_Load()");
            }
        }
        //Suspend the layout for the update
        this.SuspendLayout();
        this.someFlowLayoutPanelToStoreMyPlugins.SuspendLayout();
        foreach(IMyPlugin plugin in pluginsList)
        {
            this.someFlowLayoutPanelToStoreMyPlugins.Controls.Add(plugin.GetControl());
        }
        //resume the layout
        this.someFlowLayoutPanelToStoreMyPlugins.ResumeLayout(false);
        this.someFlowLayoutPanelToStoreMyPlugins.PerformLayout();
        this.ResumeLayout();
    }
    //////////////////////
    // In your plugin DLL.
    public class Plugin : UserControl, IMyPlugin
    {
        public Plugin()
        {
            //The code in the main form requires there be a public 
            //  no parameter constructor (either explicitly or implicitly),
            //  UserControls usually have one anyway for InitializeComponent.
            InitializeComponent();
        }
        public Control GetControl()
        {
            return this;
        }
        // The rest of your code.
    }
