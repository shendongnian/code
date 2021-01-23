    public Mainform()
    {
        InitializeComponent();     
        // read out the .ConnectionString property - don't call .ToString() !!
        string cs = ConfigurationManager.ConnectionStrings["Connectionstring"].ConnectionString;
        st.con = new SqlConnection(cs);
    }
