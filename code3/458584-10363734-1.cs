    private void button5_Click(object sender, RoutedEventArgs e)
    {
     string str="";
     foreach (UIElement child in canvas.Children)
     {
       if(child  is CheckBox)
         if(((CheckBox)child).IsChecked)
           str+=((CheckBox)child).Content;
          
     }
     string fp6 = @"D:\List2.txt";
     File.WriteAllText(fp6,str);
    }
