    private AddItemCallBack AddItemDelegate;
    private delegate void AddItemCallBack(int Total); 
            
    private void AddItemMethod(int Total)
    {
        progressBar1.Maximum = Total; 
        if (progressBar1.Value < progressBar1.Maximum)
        {
            progressBar1.Value = progressBar1.Value + 1;
        } 
        else 
        { 
            progressBar1.Value = 0; 
        }
    }
    
    public Form1()
    {
        InitializeComponent();
        AddItemDelegate = new AddItemCallBack(AddItemMethod);
    }
