	using System;
	using System.Drawing;
	using System.Windows.Forms;
	namespace LabelMaxChars
	{
		public partial class Form1 : Form
		{
			private Panel pnlStrip;
			private Label lblText;
			private Timer timer;
			public Form1()
			{
				InitializeComponent();
				pnlStrip = new Panel();
				pnlStrip.Dock = DockStyle.Top;
				pnlStrip.Height = 64;
				pnlStrip.BackColor = SystemColors.ActiveCaption;
				pnlStrip.ForeColor = Color.White;
				lblText = new Label();
				lblText.Font = new Font("Microsoft Sans Serif", 12.0f, FontStyle.Regular, 
										GraphicsUnit.Point, ((byte)(0)));
				lblText.Location = new Point(582, 6);
				lblText.AutoSize = true;
				lblText.UseCompatibleTextRendering = true;
				lblText.Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. "+
								"Sed vestibulum elit ac nunc feugiat, non varius enim commodo. "+
								"Etiam congue, massa sollicitudin congue dapibus, odio erat blandit "+
								"lectus, non vehicula nisi lacus sed orci. Vestibulum ante ipsum primis "+
								"in faucibus orci luctus et ultrices posuere cubilia Curae; Donec ullamcorper "+
								"feugiat dui, at imperdiet elit pulvinar in. Sed ac fermentum massa. "+
								"Mauris hendrerit magna sit amet mi eleifend fringilla. "+
								"Donec pretium augue gravida enim fermentum placerat. "+
								"Vestibulum malesuada nisl a odio imperdiet condimentum. Sed vitae neque nulla. "+
								"Curabitur sed facilisis odio. Integer adipiscing, ante ac cursus dignissim, "+
								"ante sapien auctor ligula, id faucibus elit mauris nec nulla. "+
								"Sed elementum nisl id quam convallis dictum. Nullam nulla turpis, "+
								"elementum ac nisi in, faucibus eleifend est. ";
				lblText.Text += lblText.Text;
				lblText.Text += lblText.Text;
				lblText.Text += lblText.Text;
				lblText.Text += lblText.Text;
				Console.WriteLine("Text length {0}", lblText.Text.Length);
				pnlStrip.Controls.Add(lblText);
				this.Controls.Add(pnlStrip);
				timer = new Timer();
				timer.Interval = 10;
				timer.Enabled = true;
				timer.Tick += new EventHandler(timer_Tick);
			}
			private void timer_Tick(object sender, EventArgs e)
			{
				--lblText.Left;
				if (lblText.Left == this.ClientSize.Width >> 1)
				{
					lblText.Text = "Nullam id nisl tortor. Donec in commodo magna. Integer dignissim vestibulum ipsum, " +
					"ac lobortis nisl faucibus ac. Pellentesque convallis placerat est, " +
					"non tempus mi scelerisque in. Sed vel aliquam tellus. " +
					"Donec tincidunt elit et imperdiet egestas. Cras vel dictum lacus. " +
					"Nullam mollis neque ac lectus congue, eget imperdiet risus feugiat. " +
					"In commodo odio quis purus scelerisque, ut vestibulum justo vulputate. " +
					"Proin sit amet facilisis libero. Donec mollis, enim at ultrices rhoncus, " +
					"quam lectus condimentum ante, a varius urna nisl rutrum mi. " +
					"Pellentesque sodales tincidunt suscipit. Cras semper sem vulputate, " +
					"ornare eros sed, fringilla libero. Sed risus turpis, mollis vitae dictum eu, " +
					"malesuada et magna. Etiam quis orci nunc. Morbi mattis ante a nibh hendrerit vehicula. ";
					lblText.Text += lblText.Text;
					lblText.Text += lblText.Text;
					lblText.Text += lblText.Text;
					lblText.Text += lblText.Text;
	
					Console.WriteLine("Text length {0}", lblText.Text.Length);
				}
			}
		}
	}
