    private string m_username;
    public string username {
        get { return m_username; }
        set { m_username = (value != null ? value.Trim() : value); }
    }
