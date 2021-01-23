    <Button Command="{Binding PushButtonCommand}"..
    some class MyClass
    {
        public ICommand PushButtonCommand
        {
            get
            {
               return _pushButtonCommand ??
                    (_pushButtonCommand = new DelegateCommand(ExecutePushButton));
            }
         }
        private void ExecutePushButton()
        {
             //lets pretend it sets some property that you need to test;
             NeedBacon = true;   
        }
        
        
