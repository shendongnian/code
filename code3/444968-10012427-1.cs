    private void button1_Click(object sender, RoutedEventArgs e)
    {
         Button btn = sender as Button;
         CounterMessage msgOne = new CounterMessage(btn.Text);
         msgOne.ShowDialog();      
    }
