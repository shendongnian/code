    public event EventHandler OpenSecondTabPage;
    public Form2() {
      InitializeComponent();
      button1.Click += button1_Click;
    }
    private void button1_Click(object sender, EventArgs e) {
      OnOpenSecondTabPage();
    }
    protected void OnOpenSecondTabPage() {
      if (OpenSecondTabPage != null) {
        OpenSecondTabPage(this, EventArgs.Empty);
      }
    }
