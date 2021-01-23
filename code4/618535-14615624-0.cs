      ObservableCollection<string> b= new ObservableCollection<string>();
    
      public void BindComboBox(ComboBox comboBoxName)
        {
    
            b.Add("a");
            b.Add("b");
            b.Add("c");
            b.Add("d");
    
            comboBoxName.ItemsSource = b;  
    
    
        }
    
    
     private void button1_Click(object sender, RoutedEventArgs e)
        {
            b.Add(textBox2.Text);
    
        }
