    private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            string text = "this is a TextBlock";
            textBlock1.Text = text;
            textBlock1.Inlines.Clear();
            int index = text.IndexOf(textBox1.Text);
            int lenth = textBox1.Text.Length;
            if (!(index < 0))
            {
                Run run = new Run() { Text = text.Substring(index, lenth), FontWeight = FontWeights.ExtraBold };
                run.Foreground = new SolidColorBrush(Colors.Orange);
                textBlock1.Inlines.Add(new Run() { Text = text.Substring(0, index), FontWeight = FontWeights.Normal });
                textBlock1.Inlines.Add(run);
                textBlock1.Inlines.Add(new Run() { Text = text.Substring(index + lenth), FontWeight = FontWeights.Normal });
                textBlock1.FontSize = 30;
                textBlock1.Foreground = new SolidColorBrush(Colors.White);
            }
            else 
            {
                textBlock1.Text = "No Match";
            }
        }
