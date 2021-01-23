    // PS: this is pseudocode ;-) or could be your new property template
    private [Type] m_[PropertyName].ToPascaleCase
    public [Type] PropertyName
    {
        get { return m_[PropertyName].ToPascaleCase; }
        set
        {
            if(m_[PropertyName].ToPascaleCase != value){
                SetChanged([PropertyName]);
                m_[PropertyName].ToPascaleCase = value;
            }
        }
    }
