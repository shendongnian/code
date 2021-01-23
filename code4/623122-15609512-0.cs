    private GameObject panel1 = null;
    private GameObject panel2 = null;
    void Start()
    {
        panel1 = GameObject.Find("Panel1");
        panel2 = GameObject.Find("Panel2");
    }
    
    void OnClick()
    {
        panel2.SetActiveRecursively(true);
        panel1.SetActiveRecursively(false);
    }
