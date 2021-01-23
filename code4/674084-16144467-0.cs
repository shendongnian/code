    protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    Session["Flag"] = null;
                    Session["Language"] = null;
                    
                    rm = new ResourceManager("Resources.Language",
                             System.Reflection.Assembly.Load("App_GlobalResources"));
    
                    LoadLanguage();
                }
            }
    
            private void LoadLanguage()
            {
                lblHindi.Text = rm.GetString("SOME_KEY1", new CultureInfo("hi-IN"));
                lblTelugu.Text = rm.GetString("SOME_KEY1", new CultureInfo("te-IN"));
            }
