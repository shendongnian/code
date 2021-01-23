    public string Fullname
    {
        get
        {
            return string.Format("{0}, {1}", Last, First);
        }
        set
        {
            string[] temp = value.Split(',');
            Last = temp[0].Trim();
            First = temp[1].Trim();
        }
    }
