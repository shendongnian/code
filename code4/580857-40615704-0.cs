    DialogResult result;
    using (var popup = new Form())
    {
        popup.Size = new Size(1000, 500);
        popup.Location = new Point(Convert.ToInt32(this.Parent.Width / 2) - 500, Convert.ToInt32(this.Parent.Height / 2) - 250);
        popup.FormBorderStyle = FormBorderStyle.FixedDialog;
        popup.MinimizeBox = false;
        popup.MaximizeBox = false;
        popup.Text = "My title";
        var lbl = new Label() { Dock = DockStyle.Top, Padding = new Padding(3), Height = 30 };
        lbl.Font = new Font("Microsoft Sans Serif", 11f);
        lbl.Text = "Do you want to Continue?";
        
        // HERE you will add your dynamic button creation instead of  my hardcoded
        var btnYes = new Button { Text = "Yes", Location = new Point(700, 400) };
        btnYes.Click += (s, ea) => { ((Form)((Control)s).Parent).DialogResult = DialogResult.Yes; ((Form)((Control)s).Parent).Close(); };
        var btnNo = new Button { Text = "No", Location = new Point(900, 400) };
        btnNo.Click += (s, ea) => { ((Form)((Control)s).Parent).DialogResult = DialogResult.No; ((Form)((Control)s).Parent).Close(); };
        popup.Controls.AddRange(new Control[] { lbl, btnYes, btnNo });
        result = popup.ShowDialog(this);
                
    }
    if (result == DialogResult.Yes)
    {
        // do this
    }
    else
    {
       // do that
    }
