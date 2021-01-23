    ListBox lstRecords;
        private void IntializeDemoListbox()
        {
            lstRecords = new ListBox();
            this.Controls.Add(lstRecords);
    
            foreach (var item in employee)
            {
                lstRecords.Items.Add(item);
            }
        }
