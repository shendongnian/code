        Button c = new Button();
        c.Location = new Point(15, x);
        c.Text = textBox1.Text; 
        panel1.Controls.Add(c);
        x += 10 + c.Size.Height;
