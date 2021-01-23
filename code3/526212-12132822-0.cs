    RichTextBox richBox8 = null;
    Label label8 = null;
    private void button1_Click(object sender, EventArgs e)
    {
        richBox8 = new RichTextBox();
        richBox8.Location = new System.Drawing.Point(1, 1);
        richBox8.Size = new System.Drawing.Size(300, 200);
        richBox8.Name = "richTextBox8";
        Controls.Add(richBox8);
        label8 = new Label();
        label8.Location = new System.Drawing.Point(5, 5);
        label8.Name = "label8";
        label8.Size = new System.Drawing.Size(110, 25);
        label8.Text = "hello world";  // crucial, if there is no text, you won't see any label!
        richBox8.Controls.Add(label8);
        // adding the label once again to the form.Controls collection is unnecessary
    }
