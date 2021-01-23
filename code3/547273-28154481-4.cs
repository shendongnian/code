    public class CustomMessageBox:System.Windows.Forms.Form
    {
        Label message = new Label();
        Button b1 = new Button();
        Button b2 = new Button();
        public CustomMessageBox()
        {
        }
        public CustomMessageBox(string title, string body, string button1, string button2)
        {
            this.ClientSize = new System.Drawing.Size(490, 150);
            this.Text = title;
            b1.Location = new System.Drawing.Point(411, 112);
            b1.Size = new System.Drawing.Size(75, 23);
            b1.Text = button1;
            b1.BackColor = Control.DefaultBackColor;
            b2.Location = new System.Drawing.Point(311, 112);
            b2.Size = new System.Drawing.Size(75, 23);
            b2.Text = button2; 
            b2.BackColor = Control.DefaultBackColor;
            message.Location = new System.Drawing.Point(10, 10);
            message.Text = body;
            message.Font = Control.DefaultFont;
            message.AutoSize = true;
            this.BackColor = Color.White;
            this.ShowIcon = false;
            this.Controls.Add(b1);
            this.Controls.Add(b2);
            this.Controls.Add(message);
        }        
    }
       
