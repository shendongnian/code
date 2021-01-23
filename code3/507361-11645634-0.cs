            private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            Button b = sender as Button;
            TextBox textBox = null;
            if (b != null)
            {
                foreach (var frameworkElement in ((Grid)b.Content).Children)
                {
                    if (frameworkElement is TextBox)
                    {
                        textBox = (TextBox)frameworkElement;
                        break;
                    }
                }
            
            }
        }
