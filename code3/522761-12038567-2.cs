    DateTime startDate = DateTime.MinValue;
    DateTime endDate   = DateTime.MaxValue;
    if(!string.IsNullOrEmpty(txtComStartDate.Text))
       startDate = DateTime.ParseExact(txtComStartDate.Text, "dd/MM/yy", provider);
    if(!string.IsNullOrEmpty(txtComEndDate.Text))
       endDate = DateTime.ParseExact(txtComEndDate.Text, "dd/MM/yy", provider);
     DateTime itemDate = DateTime.Parse(itemDate);
     if (itemDate >= startDate || itemDate <= endDate || ...)            
     {
     }
