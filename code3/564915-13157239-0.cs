    public static int TemplateWidth
    {
        get { return m_templateWidth; }
        set 
        { 
            m_templateWidth = value;    
            if (PropertyChanged!=null)
            {
                 PropertyChanged(this, new PropertyChangedEventArgs("TemplateWidth"));
            }            
        }
    }
