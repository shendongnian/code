    public partial class Login : Form
    {
	
	// Old style - sqlconnect sql = new sqlconnect();
	sqlconnect sql;
    public string pass; // These arent declared and wont be of use for your sql connect class
    public string user;
    public Login()
    {
		this.pass = "123";
		this.user = "hasslarn";
		// Now that we have a login with declared variables, pass it to the sqlconnect object
		this.sql = new sqlconnect(this);
        InitializeComponent();
    }
   
	
