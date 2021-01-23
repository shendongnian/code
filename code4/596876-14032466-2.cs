        Lable _lable;
        TextBox _textBox;
        public CustomControl()
        {
            StackPanel sp=new StackPanel();
            this.Child = sp;
 
            _lable=new Lable();
            _textBox = new TextBox();           
            sp.Children.Add(_lable);
            sp.Children.Add(new TextBox(_textBox ));
            _textBox.GotFocus = tb_GF;
        } 
      
        void tb_GF(object sender, GotFocusEventArgs e)
        {
            _lable.Background = Brushes.Yellow;
        }
    }
