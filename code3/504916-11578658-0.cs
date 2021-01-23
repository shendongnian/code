    public partial class Window2 : Window
	{
        int margin = 200;
        TextBlock DynamicLine;
		public Window2()
		{
			this.InitializeComponent();
            for (int i = 1; i <= 5; i++)
            {
                DynamicLine = new TextBlock();
                DynamicLine.Name = "lbl_DynamicLine" + i;
                RegisterName(DynamicLine.Name, DynamicLine);
                DynamicLine.Width = 600;
                DynamicLine.Height = 20;
                DynamicLine.Text =i+"Dynamic TextBlock";
                DynamicLine.Margin = new Thickness(50, margin, 0, 0);
                margin = margin + 20;
                LayoutRoot.Children.Add(DynamicLine);             
            }
            for (int i = 1; i <= 5; i++)
            {
                DynamicLine = (TextBlock)this.FindName("lbl_DynamicLine" + i);
                LayoutRoot.Children.Remove(DynamicLine);
            }
            
		}
	}
