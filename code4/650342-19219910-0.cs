        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.DisplayMember = "Text";
            listBox1.Items.Add(new Sentence { Text = "abc" });
            listBox1.Items.Add(new Sentence { Text = "abc1" });
            listBox1.Items.Add(new Sentence { Text = "abc2" });
        }
        public class Sentence
        {
            public string Text { get; set; }
        }
