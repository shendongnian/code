    private void button1_Click(object sender, EventArgs e)
    {
            switch (textBox1.BackColor.ToKnownColor())
            {
                case KnownColor.Red:
                    textBox1.BackColor = Color.Green;
                    break;
                case KnownColor.Green:
                    textBox1.BackColor = Color.Blue;
                    break;
                default:
                    textBox1.BackColor = Color.Red;
                    break;
            }
    }
