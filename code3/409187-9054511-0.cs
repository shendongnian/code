    public static classDbProvider {
        public static void Initialize(){
            HttpContext.Current.ApplicationInstance.BeginRequest += CreateDb;
            HttpConetxt.Current.ApplicationInstance.EndRequest += DisposeDb;
        }
        private static void CreateDb(object sender, EventArgs e) {
            HttpContext.Items.Add("CurrentDb", new PbaDbEntities(););
        }
        private static void DisposeDb(object sender, EventArgs e)
        {
            Current.Dispose();
            HttpContext.Items.Remove("CurrentDb");
        }
        public static PbaDbEntities CurrentDb{
            get {
                return (PbaDbEntities)HttpContext.Current.Items["CurrentDb"];
            }
        }
    }
