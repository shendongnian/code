    if(!string.IsNullOrEmpty(txtage.Text))
    {
       DrawDataGridView(parsedData.Where(p=>p.Age == int.parse(txtage.Text));
    }
    else
    {.....}
