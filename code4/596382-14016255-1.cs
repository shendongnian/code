    [Register ("AppDelegate")]
    public partial class AppDelegate : UIApplicationDelegate
    {
        ...
        public Database Db {
            get;
            private set;
        }
        public override bool FinishedLaunching (UIApplication app, NSDictionary options)
        {
            ...
            Db = new Database (Path.Combine (Environment.GetFolderPath (Environment.SpecialFolder.MyDocuments), "myDb.db"));
            Db.Trace = true;
            ...
