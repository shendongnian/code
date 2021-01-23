    public List<String> info = new List<String>();
    public List<Label> labels = new List<Label>();
     
    public Form1()
    {
        InitializeComponent();
        labels.Add(label1);
        labels.Add(label2);
        labels.Add(label3);
        labels.Add(label4);
        labels.Add(label5);
    }
    private void Form1_Load(object sender, EventArgs e)
    {
         populateinfo();
         if (labels.Count > info.Count)
         {
             for (int i = 0; i < info.Count; i++)
             {
                 labels[i].Text = info[i];
             }
         }
         else
         {
             for (int i = 0; i < labels.Count; i++)
             {
                 labels[i].Text = info[i];
             }
         }
             
    }
