     private void rbtn_remove_Click(object sender, RoutedEventArgs e)
        {
            GetInstance = GetTextbox as TextBox;
            if (GetTextbox != null)
            {
                string _CurrentValue = GetInstance.Text;
                var _CareIndex = GetInstance.CaretIndex;
                if (_CareIndex > 0)
                {
                    string _Backspace = _CurrentValue.Remove(_CareIndex - 1, 1);
                    GetInstance.Text = _Backspace;                   
                    GetInstance.Focus();
                    GetInstance.CaretIndex = _CareIndex - 1;                   
                }
            }
        }
        void txt_remove_GotFocus(object sender, RoutedEventArgs e)
        {
            GetTextbox = (Control)sender;  
        }
        private void rbtn_remove_LostMouseCapture(object sender, MouseEventArgs e)
        {
            GetInstance.Focus();
        }
