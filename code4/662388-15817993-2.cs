    public class Paths
    {
        private static string _selectedServer;
        /// <summary>
        /// The current selected server.
        /// </summary>
        public static string SelectedServer
        {
            get { return _selectedServer; }
            set
            {
                _selectedServer = value;
                _updateFields();
            }
        }
        /// <summary>
        /// The location of the current selected server.
        /// </summary>
        public static string SelectedServerLocation { get; set; }
        /// <summary>
        /// The path of the application itself.
        /// </summary>
        public static string Root { get; set; }
        /// <summary>
        /// The path of the Microcraft folder.
        /// </summary>
        public static string MicrocraftFolder { get; set; }
        /// <summary>
        /// The path of the Server Files folder.
        /// </summary>
        public static string ServersFolder { get; set; }
        /// <summary>
        /// The location of the minecraft.jar file.
        /// </summary>
        public static string MinecraftJar { get; set; }
        /// <summary>
        /// The location of the bukkit.jar file.
        /// </summary>
        public static string BukkitJar { get; set; }
        /// <summary>
        /// The location of the bukkit.yml file.
        /// </summary>
        public static string BukkitYml { get; set; }
        /// <summary>
        /// The location of the server.properties file.
        /// </summary>
        public static string ServerProperties { get; set; }
        /// <summary>
        /// The location of the root xml file.
        /// </summary>
        public static string XmlRoot { get; set; }
        /// <summary>
        /// The location of the server xml file.
        /// </summary>
        public static string XmlServer { get; set; }
        public Paths(string selectedServer)
        {
            // Set any default values here
            SelectedServer = selectedServer;
        }
        private static void _updateFields()
        {
            if (string.IsNullOrEmpty(SelectedServer))
            {
                Xml.Setting.path = Environment.CurrentDirectory + "\\microcraft\\settings.xml";
                SelectedServer = Xml.Setting.GetSetting("Servers/Current", "T4G Demo");
            }
            Root = string.Format("{0}\\", Environment.CurrentDirectory);
            MicrocraftFolder = string.Format("{0}microcraft\\", Root);
            ServersFolder = string.Format("{0}servers\\", MicrocraftFolder);
            SelectedServerLocation = string.Format("{0}{1}", ServersFolder, SelectedServer);
            MinecraftJar = string.Format("{0}{1}\\minecraft.jar", ServersFolder, SelectedServer);
            BukkitJar = string.Format("{0}{1}\\bukkit.jar", ServersFolder, SelectedServer);
            BukkitYml = string.Format("{0}{1}\\bukkit.yml", ServersFolder, SelectedServer);
            ServerProperties = string.Format("{0}{1}\\server.properties", ServersFolder, SelectedServer);
            XmlRoot = string.Format("{0}settings.xml", MicrocraftFolder);
            XmlServer = string.Format("{0}{1}\\settings.xml", MicrocraftFolder, SelectedServer);
        }
    }
