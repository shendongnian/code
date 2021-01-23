           protected override void OnLoad(EventArgs e)
           {
                // combo box datasource binding
                PrepareComboBox(_mComboBox, _mBindingList);
    
                // entity data binding
                _mComboBox.DataBindings.Add("SelectedValue", _mEntity, "WifeCount");
                _mEntity.PropertyChanged += new PropertyChangedEventHandler(UpdateBinding);
    
                base.OnLoad(e);
            }
    
         
            public void UpdateBinding(Object o, PropertyChangedEventArgs e)
            {
                _mComboBox.DataBindings.Clear();
                _mComboBox.DataBindings.Add("SelectedValue", _mEntity, e.PropertyName);
            }
