    MyTextBox txtNum = new MyTextBox();
    Form1 form = new Form1();
    [STAThread]
    static void Main()
    {
        txtNum.Pasted += (sender, args) => MessageBox.Show("Pasted: " + args.ClipboardText);
        txtNum.Size = new System.Drawing.Size(578, 20);
        txtNum.Location = new System.Drawing.Point(12, 30);    
        form.Controls.Add(txtNum);
        Application.Run(form);
    }
