    public TextBox employee = new TextBox();
    
    private void InitializeHomeComponent()
    {
        //
        //employee
        //
        this.employee.Name = "Caller Name";
        this.employee.Text = "Caller Name";
        this.employee.BackColor = System.Drawing.SystemColors.InactiveBorder;
        this.employee.Location = new System.Drawing.Point(5, 160);
        this.employee.Size = new System.Drawing.Size(190, 30);
        this.employee.TabStop = false;
        this.Controls.Add(employee);
        // I loop through all of my textboxes giving them the same function
        foreach (Control C in this.Controls)
        {
            if (C.GetType() == typeof(System.Windows.Forms.TextBox))
            {
                C.GotFocus += g_GotFocus;
                C.LostFocus += g_LostFocus;
            }
         }
     }
        private void g_GotFocus(object sender, EventArgs e)
        {
            var tbox = sender as TextBox;
            tbox.Text = "";
        }
        private void g_LostFocus(object sender, EventArgs e)
        {
            var tbox = sender as TextBox;
            if (tbox.Text == "")
            {
                tbox.Text = tbox.Name;
            }
        }
