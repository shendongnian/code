    public MyLine(ShapeContainer container) : base(container)
    {
        label = new Label() { Text = "Ali_Sarshogh" };
        label.Location = new Point(0, 0);
        label.Size = new Size(100, 14);
        this.Controls.Add(label);
    }
