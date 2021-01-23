    public class LogSettings
    {
        public LogSettings()
        {
             warnings = new Warnings[3];
             for (int i=0; i<warnings.Length; i++)
             {
                  warnings[i] = new Warnings();
             }
        }
    
        public string attributeName { get; set; }//TODO: change the variable name
    
        public Warnings[] warnings;
    }
