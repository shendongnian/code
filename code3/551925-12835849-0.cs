    this.button1.Enter += new System.EventHandler(this.Control_Enter);
       this.textBox1.Enter += new System.EventHandler(this.Control_Enter);
       this.listBox1.Enter += new System.EventHandler(this.Control_Enter);
    private void Control_Enter(object sender, EventArgs e)
        {
            Control obj = (Control)sender;
            if (obj.Name == "textBox1" || obj.Name == "listBox1")
            {
                listBox1.Visible = true;
            }
            else
            {
                listBox1.Visible = false;
            }
        }
