    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int minAllowableRolls = 1;
            int maxAllowableRolls = 10;
            Random rand = new Random();
            Session["maxRolls"] = rand.Next(maxAllowableRolls - minAllowableRolls) + minAllowableRolls;
            Session["rollCount"] = 0;
            Session["runningTotal"] = 0;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        int maxRolls = (int)Session["maxRolls"];
        int rollCount = (int)Session["rollCount"];
        int runningTotal = (int)Session["runningTotal"];
        rollCount++;
        if (rollCount < maxRolls)
        {
            Random rand = new Random();
            runningTotal += rand.Next(6) + 1;
            Label1.Text = runningTotal.ToString();
        }
        else
        {
            // Game has ended
        }
        Session["rollCount"] = rollCount;
        Session["runningTotal"] = runningTotal;
    }
