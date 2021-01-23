    public void YouChanged(string propName)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(propName);
        }
    }
