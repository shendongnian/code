    DataRowView selectedValue = (CmbCnaePrin.SelectedValue as DataRowView);
    if (selectedValue != null)
    {
        cnaepr = Convert.ToInt32(selectedValue.Row["cnae_id"]);
    }
    else
    {
        cnaepr = Convert.ToInt32(CmbCnaePrin.SelectedValue);
    }
