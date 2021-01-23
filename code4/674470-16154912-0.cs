    private int _position;
    public int Position
    {
        get
        {
            if (Session["Position"] != null)
            {
                _position= Convert.ToInt32(Session["Position"]);
            }
            else
            {
                _position= 5;
            }
            return _position;
        }
        set
        {
            _position = value;
        }
    }
