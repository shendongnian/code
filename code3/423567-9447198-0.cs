    static void ShowError(string error)
    {
        var form = new Form
        {
            Text = "Unexpected Error",
            Size = new System.Drawing.Size(800, 600),
            StartPosition = FormStartPosition.CenterParent,
            ShowIcon = false,
            MinimizeBox = false,
            MaximizeBox = false
        };
        form.SuspendLayout();
        var textBox = new TextBox
        {
            Text = error,
            Name = "textBox1",
            Dock = DockStyle.Fill,
            Multiline = true,
            ReadOnly = true,
            SelectionStart = 0, // or = error.Length if you prefer
        };
        form.Controls.Add(textBox);
        form.ResumeLayout();
        form.PerformLayout();
        form.ShowDialog();
    } 
