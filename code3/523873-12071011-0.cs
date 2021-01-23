         public bool CanAddModule { get { return !String.IsNullOrWhiteSpace(Text); } }
         public string Text
         {
             get { return _text; }
             set
             {
                 if (value != _text)
                 {
                     _text = value;
                     OnPropertyChanged("Text");
                     OnPropertyChanged("CanAddModule"); // Notify dependent get-only property
                 }
             }
         }
    <!---->
    
        <TextBox Text="{Binding Text}" .../>
        <Button IsEnabled="{Binding CanAddModule}" .../>
