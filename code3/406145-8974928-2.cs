    public void UpdateBinding(Object o, EventArgs e)
            {
                _mComboBox.DataBindings.Clear();
                _mComboBox.DataBindings.Add("SelectedValue", _mEntity, "WifeCount");
            }
