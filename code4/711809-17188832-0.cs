    protected void Page_Load(object sender, EventArgs e)
    {
    //Dont bind outside as it will overwrite the BindCode() 
        if (!IsPostBack)
        {
            //Bind inhere then it wil only bind on a full refresh and not on AJAX (partial postbacks)
        }
    }
    
    public void BindCode(){
    }
