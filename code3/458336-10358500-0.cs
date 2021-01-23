    string Password = "(O*@aJY^+{PC";
    string Account  = "email@abc.com";
    string Name     = "Ted Nelson";
    bool pwOK       = true;
    
    Match m_name = Regex.Match(Name, @"(?=(..)).");
    while (m_name.Success)
    {
        string rxpw = ".*(" + Regex.Escape(m_name.Groups[1].Value) + ")";
        Match m_passw = Regex.Match(Password, rxpw, RegexOptions.IgnoreCase);
        if (m_passw.Success)
        {
            Console.WriteLine("failed, password has name letters '" + m_passw.Groups[1].Value + "\'n");
            // pwOK = false;
            // break
        }
        m_name = m_name.NextMatch();
    }
    Match m_acct = Regex.Match(Account, @"(?=(..)).");
    while (pwOK && m_acct.Success)
    {
        string rxpw = ".*(" + Regex.Escape(m_acct.Groups[1].Value) + ")";
        Match m_passw = Regex.Match(Password, rxpw, RegexOptions.IgnoreCase);
        if (m_passw.Success)
        {
            Console.WriteLine("failed, password has account letters '" + m_passw.Groups[1].Value + "'\n");
            // pwOK = false;
            // break
        }
        m_acct = m_acct.NextMatch();
    }
    // if (pwOK) ...
