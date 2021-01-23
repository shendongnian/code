         class ReceiptItem
        {
            public int Quantity { get; set; }
            public string Description { get; set; }
            public override string ToString()
            {
                return string.Format("{0}\t{1}", Quantity, Description);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var matches = Regex.Matches(textBox1.Text, @"(\d+)\s+([A-Z\s\*\#]*[A-Z]+)", RegexOptions.Multiline);
            var items = (from Match m in matches
                         select new ReceiptItem()
                                    {
                                        Quantity = int.Parse(m.Groups[1].Value),
                                        Description = Regex.Replace(m.Groups[2].Value, @"(\*\#(\s*))|(\r\n\s+)(?=\s)", "")
                                    });
            listBox1.Items.AddRange(items.ToArray());
        }
