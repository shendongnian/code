    public class Form2 : Form
    {
        private TextBox textBox1;
        private TextBox textBox2;
        public string TextValue1 { get; set; }
        public string TextValue2 { get; set; }
        public Form2()
        {
            this.Load += new EventHandler((object sender, EventArgs e) =>
            {
                textBox1.Text = TextValue1;
                textBox2.Text = TextValue2;
            });
        }
    }
