    void Main()
    {
    	var f = new Form 
    	{
    		Width = 800,
    		Height = 600
    	};
    	var d = new Form
    	{
    		Width = 400,
    		Height = 300
    	};
    	var tb = new TextBox 
    	{ 
    		Width = 250, 
    		Height = 250, 
    		Multiline = true, 
    		Text = "Hello World", 
    		Dock = DockStyle.Top 
    	};
    	var b = new Button
    	{
    		Text = "Display Masked Dialog",
    		Dock = DockStyle.Top
    	};
    	b.Click += (s, e) => 
    	{
    		MaskedDialog.ShowDialog(f, d);
    	};
    	f.Controls.AddRange(new Control[] { tb, b } );
    	Application.Run(f);
    }
    
    public class MaskedDialog : Form
    {
        private Form dialog;
        private MaskedDialog(Form parent, Form dialog)
        {
            this.dialog = dialog;
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = System.Drawing.Color.Black;
            this.Opacity = 0.50;
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.Manual;
            this.Size = parent.ClientSize;
            this.Location = parent.PointToScreen(System.Drawing.Point.Empty);
            parent.Move += AdjustPosition;
            parent.SizeChanged += AdjustPosition;
        }
        private void AdjustPosition(object sender, EventArgs e)
        {
            Form parent = sender as Form;
            this.Location = parent.PointToScreen(System.Drawing.Point.Empty);
            this.ClientSize = parent.ClientSize;
        }
        public static DialogResult ShowDialog(Form parent, Form dialog)
        {
            var mask = new MaskedDialog(parent, dialog);
            dialog.StartPosition = FormStartPosition.CenterParent;
            mask.Show();
            var result = dialog.ShowDialog(mask);
            mask.Close();
            return result;
        }
    } 
