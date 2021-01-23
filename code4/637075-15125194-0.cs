    class Program
    {
        static void Main(string[] args)
        {
            //Environment.CurrentDirectory = @"c:\Program Files (x86)\Microsoft Visual SourceSafe Upgrade";
            IVSSDatabase db = new VSSDatabase();
            db.Open(@"ThePath\srcsafe.ini", "Admin", "ThePassword");
            IVSSItem rootFolder = db.get_VSSItem("$/", false);
            var versions = new List<VersionInfo>();
            foreach (IVSSVersion item in rootFolder.get_Versions((int)Microsoft.VisualStudio.SourceSafe.Interop.VSSFlags.VSSFLAG_RECURSYES))
            {
                versions.Add(new VersionInfo()
                {
                    ItemName = item.VSSItem.Name,
                    ItemFullPath = item.VSSItem.Spec,
                    ItemVersionDate = item.Date,
                    ItemVersionNumber = item.VersionNumber
                });
            }
            // echo all 
            var versionInfo = versions.OrderByDescending(i => i.ItemVersionDate).First();
            Console.WriteLine("{0} {1}", versionInfo.ItemFullPath, versionInfo.ItemVersionDate);
            Console.ReadLine();
        }
    }
    class VersionInfo
    {
        public string ItemName { get; set; }
        public string ItemFullPath { get; set; }
        public DateTime ItemVersionDate { get; set; }
        public int ItemVersionNumber { get; set; }
    }</code>
