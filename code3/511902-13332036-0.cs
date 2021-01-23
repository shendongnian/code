     public void SetMSG(string text){
            if (StatTextBox.Dispatcher.CheckAccess())
            {
                StatTextBox.Text = text;
            }
            else
            {
                SetTextCallback d = new SetTextCallback(SetText);
                StatTextBox.Dispatcher.Invoke(DispatcherPriority.Normal, d, text);
            }
        }
        delegate void SetTextCallBack(string Text);
  
        public void SetText(string text){
            StatTextBox.Text=text;
        }  
