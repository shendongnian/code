          public Form1()
          {
               InitializeComponent();
               button1.MouseEnter += control_MouseEnter;
               button1.MouseLeave += control_MouseLeave;
               button2.MouseEnter += control_MouseEnter;
               button2.MouseLeave += control_MouseLeave;
          }
          void control_MouseEnter(object sender, EventArgs e)
          {
               Control control = sender as Control;
               if (control != null)
                   control.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.img1));
          }
          void control_MouseEnter(object sender, EventArgs e)
          {
               Control control = sender as Control;
               if (control != null)
                   control.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.img2));
          }
