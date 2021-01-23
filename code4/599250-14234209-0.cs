     string filepath;
            //browse Button
            private void button4_Click(object sender, RoutedEventArgs e)
            {
                OpenFileDialog open = new OpenFileDialog();
                open.Multiselect = false;    
                open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
                bool? result = open.ShowDialog();
    
                if (result == true)
                {
                    filepath = open.FileName; // Stores Original Path in Textbox    
                    ImageSource imgsource = new BitmapImage(new Uri(filepath)); // Just show The File In Image when we browse It
                    Clientimg.Source = imgsource;  
                }
            }
