    public void OnMyPropChanged(System.ComponentModel.PropertyChangedEventArgs e)
    {
        Binding bb = this.DataBindings[0] as Binding;
        bb.WriteValue();
        if (MyPropChanged != null) MyPropChanged(this, e);
    }
    private void TxtChanged(object sender, EventArgs e)
    {
        if (load) { return; }
        _my_prop = Txt.Text;   // ...
        OnValueTwoChanged(new PropertyChangedEventArgs("MyProp"));
    }    
