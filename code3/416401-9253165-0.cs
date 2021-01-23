    public class SomeClass
    {
        public static void AddControl(Form form, string controlTxt)
        {
            form.AddButton(form, controlTxt);
        }
        public static void AddButton(string form, string TxtToDisplay)
        {
            Button btn = new Button();
            btn.Size = new Size(50, 50);
            btn.Location = new Point(10, yPos);
            yPos = yPos + btn.Height + 10;
            btn.Text = TxtToDisplay;
            btn.Visible = true;
            form.Controls.Add(btn);
        }
    }
    private void button1_Click(object sender, EventArgs e)
    {
        SomeClass.AddControl(this, "Hello");
    }
