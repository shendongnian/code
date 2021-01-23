        private void btnClick(object sender, EventArgs e)
        {
            var bindingSource = (sender == btnRemove) ? bindingSource2 : bindingSource1;   
            var selectedItem = source.Current as LabEntity;
            if(sender == btnRemove) 
            {
                availableLabsData.Add(selectedItem);
                selectedLabsData.Remove(selectedItem);
            }
            else if(sender == btnAdd)
            {
                availableLabsData.Remove(selectedItem);
                selectedLabsData.Add(selectedItem);
            }
        }
