    private readonly Control[] m_Controls;
    public MyControl() {
        InitializeComponent();
        
        m_Controls = new[] {
            AName1, AName2, AName3,
            BName1, BName2, BName3,
        }
    }
    private void DoStuff(string text) {
        foreach (Control c in m_Controls) {
            c.Text = text;
        }
    }
