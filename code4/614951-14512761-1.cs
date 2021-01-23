    MainWindow
    {
        private void SomeStuff()
        {
            Window1 window = new Window1();
            window.CheckBoxClick += new OnCheckBoxClick(SomeMethod);
        }
        private void SomeMethod(bool state)
        {
             // use state;
        }
    }
