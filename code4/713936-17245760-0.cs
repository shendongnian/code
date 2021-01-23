    class TextBoxData
    {
        public string[] aTextBoxes = new string[3];
        public TextBox[] TextBoxes { get; private set;}
        public TextBoxData(Form1 form)
        {
            this.TextBoxes = new TextBox[] { form.textBox1, form.textBox2, form.textBox3, form.textBox4 };
        }
        public void DataToArray()
        {
            for (int i = 0; i < TextBoxes.Length; i++)
            {
                aTextBoxes[i] = TextBoxes[i].Text;
            }
        }
        // ...
