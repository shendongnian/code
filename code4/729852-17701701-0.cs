    public partial class Form1 : Form
    {
        public class configi
        {
            public static string config;
            static configi()
            {
                try
                {
                    config = File.ReadAllText("config.ini");
    
                }
                catch (FileNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }
        }
        public Form1()
        {
            InitializeComponent();
    
        }
    
        static string username = (Environment.GetEnvironmentVariable("USERNAME"));
        static string Backups = configi.config + @"\" + username + @"\" + "Backups" + @"\";
        static string items;
           
