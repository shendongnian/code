            try
            {
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    Button btn = new Button();
                    btn.Width = 100;
                    btn.Height = 50;
                    btn.Content = "Test";
                    myG.Children.Add(btn);
                }
                ));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
