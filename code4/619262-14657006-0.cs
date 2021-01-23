    public partial class Form1 : Form
    {
        // Prerequisites to run:
        //      1)  Project, Add Reference, Projects, ContractInterface
        //      2)  Project, Add Reference, .NET, System.ComponentModel.Composition
        [ImportMany(typeof(IPlugIn))]
        private IEnumerable<Lazy<IPlugIn, IPlugInMetadata>> LoadedPlugIns;
        List<PlugInInfo> AvailablePlugIns = null;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // Get a list of the available Plug-Ins
            AvailablePlugIns = GetPlugInList();
            // Prepare an ImageList to hold the DLL icons
            ImageList ImgList = new ImageList();
            ImgList.ColorDepth = ColorDepth.Depth32Bit;
            ImgList.ImageSize = new Size(32, 32);
            
            // Populate ImageList with Plug-In Icons
            foreach (var item in AvailablePlugIns)
            {
                ImgList.Images.Add(item.PlugInIcon.ToBitmap());
            }
            // Assign the ImageList to the ListView
            listView1.LargeImageList = ImgList;
            int imageIndex = 0;
            // Create the ListView items
            foreach (var item in AvailablePlugIns)
            {
                listView1.Items.Add(item.PlugInTitle, imageIndex);
                imageIndex++;
            }
            listView1.MouseDoubleClick += new MouseEventHandler(listView1_MouseDoubleClick);
        }
        void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // Get the Plug-In index number 
            int plugInNum = listView1.SelectedItems[0].Index;
            PlugInInfo selectedPlugIn = AvailablePlugIns[plugInNum];
            // Call the StartPlugIn method in the selected Plug-In.
            // Lazy Instantiation will fully load the Assembly here
            selectedPlugIn.PlugIn.StartPlugIn(this);
            Console.WriteLine("Plug-In Title:          {0}", selectedPlugIn.PlugInTitle);
            Console.WriteLine("Plug-In Description:    {0}", selectedPlugIn.PlugInDescription);
            Console.WriteLine("Plug-In Version:        {0}", selectedPlugIn.PlugInVersion);
            Console.WriteLine();
        }
        private List<PlugInInfo> GetPlugInList()
        {
            // Create a List to hold the info for each plug-in
            List<PlugInInfo> plugInList = new List<PlugInInfo>();
            // Set Plug-In folder path to same directory level as Solution
            string plugInFolderPath = System.IO.Path.Combine(Application.StartupPath, @"..\..\..\Plug-Ins");
            // Test if the Plug-In folder exists
            if (!Directory.Exists(plugInFolderPath))
            {
                // Plug-In Folder is missing, so try to create it
                try
                { Directory.CreateDirectory(plugInFolderPath); }
                catch
                { MessageBox.Show("Failed to create Plug-In folder", "Folder Creation Error:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            }
            try
            {
                // Create a catalog of plug-ins
                var catalog = new DirectoryCatalog(plugInFolderPath, "*.dll");
                AggregateCatalog plugInCatalog = new AggregateCatalog();
                plugInCatalog.Catalogs.Add(catalog);
                CompositionContainer container = new CompositionContainer(plugInCatalog);
                
                // This line will fetch the metadata from each plug-in and populate LoadedPlugIns
                container.ComposeParts(this);
                // Save each Plug-Ins metadata
                foreach (var plugin in LoadedPlugIns)
                {
                    PlugInInfo info = new PlugInInfo();
                    info.PlugInTitle = plugin.Metadata.PlugInTitle;
                    info.PlugInDescription = plugin.Metadata.PlugInDescription;
                    info.PlugInVersion = plugin.Metadata.PlugInVersion;
                    info.PlugIn = plugin.Value;
                    plugInList.Add(info);
                }
                int index = 0;
                // Extract icons from each Plug-In DLL and store in Plug-In list
                foreach (var filePath in catalog.LoadedFiles)
                {
                    plugInList[index].PlugInIcon = Icon.ExtractAssociatedIcon(filePath);
                    index++;
                }
            }
            catch (FileNotFoundException fex)
            {
                Console.WriteLine("File not found exception : " + fex.Message);
            }
            catch (CompositionException cex)
            {
                Console.WriteLine("Composition exception : " + cex.Message);
            }
            catch (DirectoryNotFoundException dex)
            {
                Console.WriteLine("Directory not found exception : " + dex.Message);
            }
            return plugInList;
        }
    }
    public class PlugInInfo
    {
        public string PlugInTitle { get; set; }
        public string PlugInDescription { get; set; }
        public string PlugInVersion { get; set; }
        public Icon PlugInIcon { get; set; }
        public IPlugIn PlugIn { get; set; }
    }
