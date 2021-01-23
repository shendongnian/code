    private void button1_Click(object sender, RoutedEventArgs e)
            {
                int test = int.Parse(textBox1.Text);
    
                string[] nr = new string[3]{"this string is 1","this string is 2","this string is 3"};
                MessageBox.Show(nr[test-1]);
            }
