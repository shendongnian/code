    private int _position;
    public int Position
    {
        get
        {
            if (Session["Position"] != null)
            {
                this._position = Convert.ToInt32(Session["Position"]);
            }
            else
            {
                this._position = 5;
            }
            return this._position;
        }
        set
        {
            this._position = value;
        }
    }
     
