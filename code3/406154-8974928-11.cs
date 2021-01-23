    protected override void OnLoad(EventArgs e)
    {
        // combo box datasource binding
        PrepareComboBox(_mComboBox, _mBindingList);
                    
        // entity data binding
        UpdateBindings();
                       
        base.OnLoad(e);
    }
                   
    
    public void UpdateBindings()
    {
        _mComboBox.DataBindings.Clear();
        if (_mBindingList.Count != 0) _mComboBox.DataBindings.Add("SelectedValue", _mEntity, "WifeCount");
    }
    
    void _mAssignButton_Click(object sender, EventArgs e)
    {
        _mBindingList.Clear();          
        foreach (var o in _mCacheList) _mBindingList.Add(o);
        // UPDATE BINDINGS HERE - Only do this if changing the binding source
        UpdateBindings();
    
        _mEntity.WifeCount = 3M;
    
        this.Text = string.Format("SelectedValue: {0}; WifeCount: {1}", _mComboBox.SelectedValue, _mEntity.WifeCount);
    }
