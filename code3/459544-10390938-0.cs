    public override bool Equals(object ob)
    {
      if (ob is TwoDoubles)
        return Equals((TwoDoubles)ob);
      else
        return false;
    }
    public bool Equals(TwoDoubles c)
    {
      return m_Re == c.m_Re && m_Im == c.m_Im;
    }
