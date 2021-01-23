    private void btnClick(object sender, EventArgs e)
    {
    Button *myButton = (Button)sender;
    if (myButton.tag == 1){
            LabEntity selectedItem = bindingSource1.Current as LabEntity;
            selectedLabsData.Add(selectedItem);
            availableLabsData.Remove(selectedItem);
    }
    else {
    LabEntity selectedItem = bindingSource2.Current as LabEntity;//new binding source
            availableLabsData.Add(selectedItem);//called Add instead of remove
            selectedLabsData.Remove(selectedItem);//called Remove instead of Add
    }
    }
