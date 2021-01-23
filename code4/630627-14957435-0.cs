        ContextMenu ContextMenu1;
        MenuItem menuItem1;
        MenuItem menuItem2;
        public Form1()
        {
            InitializeComponent();
            ContextMenu1 = new System.Windows.Forms.ContextMenu();
            menuItem1 = new System.Windows.Forms.MenuItem();
            menuItem2 = new System.Windows.Forms.MenuItem();
            ContextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { menuItem1, menuItem2 });
            InitializeChart();
        }
      Steema.TeeChart.Styles.Line line; 
      private void InitializeChart()
      {
          line = new Line(tChart1.Chart);
          line.FillSampleValues();
          tChart1.MouseUp  = new MouseEventHandler(tChart1_MouseUp);
      }
    
    
      void tChart1_MouseUp(object sender, MouseEventArgs e)
      {
          if (e.Button == System.Windows.Forms.MouseButtons.Right)
          {
              menuItem1.Index = 0;
              menuItem1.Text = "From:"   Math.Round(tChart1[0].XScreenToValue(e.X)).ToString();
              menuItem2.Index = 1;
              menuItem2.Text = "To:"   Math.Round(tChart1[0].XScreenToValue(e.X)).ToString();
              ContextMenu1.Show(tChart1, new Point(e.X, e.Y));
          }
      }
