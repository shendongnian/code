    private RelayCommand _aaa;
    
            public RelayCommand AAA
            {
                get
                {
                    return _aaa ??(_aaa =new RelayCommand(ExecuteAAA, CanExecuteAAA));
                }
            }
    
            private void ExecuteAAA()
            {    
              if (System.Windows.Forms.Control.ModifierKeys == System.Windows.Forms.Keys.Shift)
              {
                 MessageBox.Show("111");
              }
            }
    
           private bool CanExecuteAAA()
            {
                return true;
            }
