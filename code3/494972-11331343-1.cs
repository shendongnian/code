    class NewUC : UserControl
    {
        public event EventHandler CloseClicked;
        public override void OnApplyTemplate()
        {
            Button btn = this.FindName("SomeButton") as Button;
            if (btn == null) throw new Exception("Couldn't find 'Button'");
            btn.Click += new System.Windows.RoutedEventHandler(btn_Click);
        }
        void btn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            OnCloseClicked();
        }
        private void OnCloseClicked()
        {
            if (CloseClicked != null)
                CloseClicked(this, EventArgs.Empty);
        }
    }    
