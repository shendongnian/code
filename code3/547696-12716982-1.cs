    //In a 2nd project that compiles as a DLL
    public abstract class IMyPlugin
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
                Type assemblyInterface = pluginAssembly.GetType("PluginNamespace.Plugin");
        
                //instantiate object if it supports the interface
                if (assemblyInterface != null)
                {
                    //instantiate the object
                    IMyPluginplugin = (IMyPlugin)Activator.CreateInstance(assemblyInterface);
                    
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
    namespace PluginNamespace
    {
        //In your plugin, This must match the namespace you had in pluginAssembly.GetType("PluginNamespace.Plugin");
        public class Plugin : UserControl, IMyPlugin
        {
           //(Snip)
        }
    }
