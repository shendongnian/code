    class Sample
    {
    	public Sample()
    	{
    		listToWatch = new List<string>();
    	}
    
        public static List<string> listToWatch
        {
            get;
            set;
        }
    
        public static void firstMethod()
        {
            string[] getFiles = Directory.GetFiles(directory, "*.xml");
            foreach (string xmlFile in getFiles)
            {
                secondMethod(xmlFile);
            }
        }
    
        public static void secondMethod(xmlFile)
        {
            foreach (string file in xmlFile)
            {
                if (listToWatch.Contains(file))
                {
                    sw.WriteLine(file + " is already added!");
                }
                else
                {
                    listToWatch.add();
                }
            }
        }
    }
