    public string[] RegisterLabels { get; private set; }
    private void Generatelabels()
    {
        string[] labels = new string[8];
        int baseRegister = 0x40 * ID;
        for (int i = 0; i < 8; i++)
        {
            int reg = (i * 8) + baseRegister;
            labels[i] = "Reg 0x" + reg.ToString("X");
        }
        RegisterLabels = labels;
        OnPropertyChanged("RegisterLabels");
    }
