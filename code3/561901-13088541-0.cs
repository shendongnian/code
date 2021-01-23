    public void Page_Load(object sender, EventArgs e)
    {
        // You need to determine if you should call PeerReview every time the page 
        // loads, or only on the initial call of the page, thus determining whether
        // you need the IsPostBack() test. My instinct is that you *do* want to constrain
        // it to the first pass, but only you can make that determination for
        // certain based on your requirements.
    
        if (!Page.IsPostBack)  //Do you need this check?
        {
            PeerReview();
        }
    }
