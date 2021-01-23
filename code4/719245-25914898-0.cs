    public partial class _Default : System.Web.UI.Page
    {
       static DateTime dt = new DateTime(2014,9,1,0,0,0,000);
       Timer t = new Timer();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Timer1.Enabled = false; 
                Timer1.Interval = 1;
                lbl.Text = dt.ToLongTimeString() + ":" + dt.Millisecond;
            }
        }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        dt = dt.AddMilliseconds(1);
        lbl.Text = dt.ToLongTimeString() + ":" + dt.Millisecond;
    }
    protected void Reset_Click(object sender, EventArgs e)
    {
        Timer1.Enabled = false; //For stop the timer
        dt = new DateTime(2014, 9, 1, 0, 0, 0, 000);
        lbl.Text = dt.ToLongTimeString() + ":" + dt.Millisecond;
       
    }
    protected void Pause_Click(object sender, EventArgs e)
    {
        Timer1.Enabled = false; //For stop the timer
    }
    protected void Start_Click(object sender, EventArgs e)
    {
        Timer1.Enabled = true; // For starting the timer
    }
}
