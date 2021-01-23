    public sealed class LanguageManager
    {
        /// <summary>
        /// Default CultureInfo
        /// </summary>
        public static readonly CultureInfo DefaultCulture = new CultureInfo("en-US");
    
        /// <summary>
        /// Available CultureInfo that according resources can be found
        /// </summary>
        public static readonly CultureInfo[] AvailableCultures;
    
        static LanguageManager()
        {
            List<string> availableResources = new List<string>();
            string resourcespath = Path.Combine(System.Web.HttpRuntime.AppDomainAppPath, "App_GlobalResources");
            DirectoryInfo dirInfo = new DirectoryInfo(resourcespath);
            foreach (FileInfo fi in dirInfo.GetFiles("*.*.resx", SearchOption.AllDirectories))
            {
                //Take the cultureName from resx filename, will be smt like en-US
                string cultureName = Path.GetFileNameWithoutExtension(fi.Name); //get rid of .resx
                if (cultureName.LastIndexOf(".") == cultureName.Length - 1)
                    continue; //doesnt accept format FileName..resx
                cultureName = cultureName.Substring(cultureName.LastIndexOf(".") + 1);
                availableResources.Add(cultureName);
            }
    
            List<CultureInfo> result = new List<CultureInfo>();
            foreach (CultureInfo culture in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
            {
                //If language file can be found
                if (availableResources.Contains(culture.ToString()))
                {
                    result.Add(culture);
                }
            }
    
            AvailableCultures = result.ToArray();
    
            CurrentCulture = DefaultCulture;
            if (!result.Contains(DefaultCulture) && result.Count > 0)
            {
                CurrentCulture = result[0];
            }
        }
    
        /// <summary>
        /// Current selected culture
        /// </summary>
        public static CultureInfo CurrentCulture
        {
            get { return Thread.CurrentThread.CurrentCulture; }
            set
            {
                Thread.CurrentThread.CurrentUICulture = value;
                Thread.CurrentThread.CurrentCulture = value;
            }
        }
    }
