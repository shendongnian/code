          List<LookupListItem> EmpStatuses = new List<LookupListItem>();
            foreach (EmploymentStatuses m in Enum.GetValues(typeof(EmploymentStatuses)))
            {
                EmpStatuses.Add(new LookupListItem((int)m, m.ToString()));
            }
        
    EmpStatuses.Add(new LookupListItem(<selectedValue>, "SomeText")); //<- my modified code
        
            cboStatus.DataSource = EmpStatuses; // Enum.GetValues(typeof(CommonLibrary.Lookups.EmploymentStatuses));
            cboStatus.ValueMember = "ItemValue";
            cboStatus.DisplayMember = "ItemDesc";
            // Remove this part cboStatus.DataBindings.Add("SelectedValue", _presenter.SelectedOfficer, "EmploymentStatusID");
    
    cboStatus.SelectedValue = <selectedValue> //<- my modified code
