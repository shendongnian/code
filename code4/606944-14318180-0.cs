    int i = 0;
    private void button1_Click(object sender, RoutedEventArgs e)
    {   
       listBox1.Items.Add("Item nr. " + i.ToString());
       listBox1.ScrollIntoView("Item nr. " + i.ToString());
       i++;
    }
