    private int number = 0;
    public int par
    {
        get
        {
            return number;
        }
        set
        {
            number = value;
        }
    }
    protected void LoadMore_Click(object sender, EventArgs e)
    {
        number++;
        lblShow.Text = par.ToString();
 
        try
        {
            loadNews(par);
        }
        catch(Exception ex)
        { 
            lblShow.Text += ex.Message; 
        }
    }
