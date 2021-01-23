    private void button2_Click(object sender, EventArgs e) {
        button2.Enabled = false;
        TextBox tbox8 = new TextBox();
        tbox8.Name = "textBox8";
        tbox8.Location = new System.Drawing.Point(54 + (0), 55);
        tbox8.Size = new System.Drawing.Size(53, 20);
        this.Controls.Add(tbox8);
        tbox8.BackColor = System.Drawing.SystemColors.InactiveCaption;
        TextBox tbox9 = new TextBox();
        tbox9.Name = "textBox9";
        tbox9.Location = new System.Drawing.Point(54 + (60), 55);
        tbox9.Size = new System.Drawing.Size(53, 20);
        this.Controls.Add(tbox9);
        tbox9.BackColor = System.Drawing.SystemColors.InactiveCaption; }
    private void button3_Click(object sender, EventArgs e) {
        double result = 0;
        double.TryParse(tbox8.Text, out result);
        tbox9.Text = (double)(result * 2).ToString(); }
