    int yPos = 0;
    foreach (String entry in entries)
    {
        this.SuspendLayout();
        Panel panel = new Panel();
        panel.SuspendLayout();
        panel.AutoSize = true;
        panel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
        panel.BackColor = System.Drawing.SystemColors.Window; // Allows to see that the panel is resized for dispay
        panel.Location = new System.Drawing.Point(0, yPos);
        panel.Size = new System.Drawing.Size(this.Width, 0);
        this.Controls.Add(panel);
        Label label = new Label();
        label.AutoSize = true;
        label.Location = new System.Drawing.Point(0, 0);
        label.MaximumSize = new System.Drawing.Size(panel.Width, 0);
        label.Text = entry;
        panel.Controls.Add(label);
        panel.ResumeLayout(true);
        this.ResumeLayout(true);
        yPos += panel.Height; // When breaking here, panel.Height is worth 0
        //yPos += label.Height; // This works perfectly, label.Height was updated according to the text content when breaking at that point
    }
    this.PerformLayout();
        
   
