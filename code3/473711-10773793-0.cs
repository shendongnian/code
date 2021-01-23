    void newMethod(int x, int y, Panel p)
    {
        Button B = new Button();
        B.Size = new Size(100, 30);
        B.Location = new Point(x, y);
        B.Text = "Text";
        p.Controls.Add(B);
    }
