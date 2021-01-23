    public TestForm12()
    {
       InitializeComponent();
    
       Button btn = new Button();
       btn.Width = this.Width - 10;
       btn.Height = 20;
       btn.Left = (this.ClientSize.Width - btn.Width) / 2;
       btn.Top = (this.ClientSize.Height - btn.Height) / 2;
       btn.Text = "click me";
       this.Controls.Add(btn);
       btn.Anchor = AnchorStyles.None;               
    
    }
