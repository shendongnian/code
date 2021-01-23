    public Thickness BondIndent
    {
        get
        {
            int margin = _bondSequence * 5;
            return new Thickness(margin, 0, margin, 0);
        }
    }
