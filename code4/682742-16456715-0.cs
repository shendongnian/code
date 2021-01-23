    public String Factor
    {
        get { return m_Factor; }
        set 
        { 
            m_Factor = value;
            this.ValidateElement(..);
        }
    }
    public void ValidateElement(..)
    {
            try
            {
                this.SetFieldDataError(null, ..);
                if (!string.IsNullOrEmpty(m_Factor))
                {
                    m_Factor = Double.Parse(FactorInternal).ToString();
                }
            }
            catch (Exception e)
            {
                this.SetFieldDataError("some error", ..);
            }
    }
