    private void button1_Click(object sender, EventArgs e)
    {
       Button btnAdd = new Button();
       btnAdd.BackColor = Color.Gray;
       btnAdd.Text = "Remove";
       btnAdd.Location = new System.Drawing.Point(240, 25);
       btnAdd.Size = new System.Drawing.Size(70, 25);
       TextBox txtBox = new TextBox();
       txtBox.Text = "";
       txtBox.Location = new System.Drawing.Point(150, 25);
       txtBox.Size = new System.Drawing.Size(70, 40);
       
       ComboBox combohead = new ComboBox();
       combohead.Location = new System.Drawing.Point(10, 25);
       panel1.Controls.Add(btnAdd);
       panel1.Controls.Add(txtBox);
       panel1.Controls.Add(combohead);
    }
