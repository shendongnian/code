    private void ButtonImageRemove_Click(object sender, RoutedEventArgs e)
        {
            
            image1.Source = null;
            System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ThreadStart(delegate
            {
                System.Threading.Thread.Sleep(500);
                GC.Collect();
            }));
            thread.Start();
            
        }
