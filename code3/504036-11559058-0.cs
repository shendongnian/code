    Label l = new Label();
    l.Text = "Ì CSharp Î";
    this.Font = new Font("Code 128", 80);
    l.Size = new System.Drawing.Size(300, 200);
    this.Controls.Add(l);
    this.Size = new Size(300, 200);
    var i = DrawText(l.Text, this.Font, Color.Black, Color.White);
