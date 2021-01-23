    using Nini.Config;
    public class DbConfig : PropertyNotifierBase {
        private static readonly string PROGRAM_NAME = "programname";
        private static readonly string CONFIG_NAME = "Database";
        private static DbConfig _instance = new DbConfig();
        public static DbConfig Instance { get { return (_instance); } }
        private DbConfig() {
            SetupPaths();
            Source = new XmlConfigSource(FullConfigFilename);
            Source.AutoSave = true;
            CreateSectionsIfNeeded();
        }
        private void CreateSectionsIfNeeded() {
            if (Source.Configs["Database"] == null)
                Source.AddConfig("Database");
        }
        private void SetupPaths() {
            ConfigPath = DetermineConfigPath();
            ConfigFilename = String.Format("{0}.xml", CONFIG_NAME);
            Directory.CreateDirectory(ConfigPath);
            // Create an empty configuration file if it isn't there.
            if (!File.Exists(FullConfigFilename))
                File.WriteAllText(FullConfigFilename, "<Nini>\n</Nini>\n");
        }
        private IConfigSource Source { get; set; }
        public String ConfigPath { get; private set; }
        public String ConfigFilename { get; private set; }
        public String FullConfigFilename { get { return (Path.Combine(ConfigPath, ConfigFilename)); } }
        public String SqlServerInstance {
            get { return (Source.Configs["Database"].GetString("SqlServerInstance", @"somedefaultconnection")); }
            set { Source.Configs["Database"].Set("SqlServerInstance", value); NotifyPropertyChanged("SqlServerInstance"); }
        }
        public String SqlServerDatabase {
            get { return (Source.Configs["Database"].GetString("SqlServerDatabase", "somedatabasename")); }
            set { Source.Configs["Database"].Set("SqlServerDatabase", value); NotifyPropertyChanged("SqlServerDatabase"); }
        }
        public String SqlServerUsername {
            get { return (Source.Configs["Database"].GetString("SqlServerUsername", "someusername")); }
            set { Source.Configs["Database"].Set("SqlServerUsername", value); NotifyPropertyChanged("SqlServerUsername"); }
        }
        public String SqlServerPassword {
            get { return (Source.Configs["Database"].GetString("SqlServerPassword", "somepassword")); }
            set { Source.Configs["Database"].Set("SqlServerPassword", value); NotifyPropertyChanged("SqlServerPassword"); }
        }
        private string DetermineConfigPath() {
            String filename = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            filename += Path.DirectorySeparatorChar + PROGRAM_NAME;
            return (filename);
        }
    }
