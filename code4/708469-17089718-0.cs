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
    protected void btnIncrement_Click(object sender, EventArgs e)
    {
        number++;
        lblShow.Text = par.ToString();
        loadNews(par);
    }
