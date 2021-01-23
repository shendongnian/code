    protected void Page_Load(object sender, EventArgs ea)
    {
        bool? addHotelResultButton = ViewState["AddHotelResultButton"] as bool?;
        if (addHotelResultButton.HasValue && addHotelResultButton.Value)
        {
            AddHotelResultButton();
        }
    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        ViewState["AddHotelResultButton"] = true;
        AddHotelResultButton();
    }
    protected void AddHotelResultButton()
    {
        Timer1.Enabled = false;
        Label1.Text = DateTime.Now.ToString();
        Label2.Text = DateTime.Now.ToString();
        Label3.Text = DateTime.Now.ToString();
        ImageButton testbtn = new ImageButton();
        testbtn.ID = "testbtnid";
        testbtn.Click += new System.Web.UI.ImageClickEventHandler(this.imgBtn_Click);
        testbtn.ImageUrl = "images/heroAccent.png";
        PlaceHolder1.Controls.Add(testbtn);
    }
