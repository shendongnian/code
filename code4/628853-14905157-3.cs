        private void button1_Click(object sender, EventArgs e)
        {
            List<Numbers> list = new List<Numbers>();
            string[] text = textBox1.Text.Select(x => x.ToString()).ToArray();
            foreach (var i in text)
            {
                list.Add(new Numbers
                {
                    oneColumn = decimal.Parse(i),
                    twoColumn = (decimal.Parse(i) / 15) * 100
                });
            }
            label1.Text = list.Sum(c => c.twoColumn).ToString("#,#0.00");
        }
