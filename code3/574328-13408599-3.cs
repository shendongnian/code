    static TextBox txtNum = new TextBox();
    [STAThread]
    static void Main()
    {
    //Application.EnableVisualStyles();
    //Application.SetCompatibleTextRenderingDefault(false);
    // txtNum.Paste += (sender, args) => MessageBox.Show("Pasted: " + args.ClipboardText);
    txtNum.Size = new System.Drawing.Size(578, 20);
    txtNum.Location = new System.Drawing.Point(12, 30);
    Form1 form = new Form1();
    form.Controls.Add(txtNum);
    Application.Run(form);
    }
