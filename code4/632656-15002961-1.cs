    public double MinimumVolume
    {
        get { return minimumVolume; }
        set
        {
            minimumVolume = value;
            txtVolumnMin.Text = minimumVolume.ToString();
        }
    }
