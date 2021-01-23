    DateTime? dt = null;
    DateTime tmp;
    if (DateTime.TryParse(
        String.Format("{0}/{1}/{2}", 
            cboDay.SelectedItem.Text
            , cboMonth.SelectedItem.Text
            , cboYear.SelectedItem.Text
        )
        , out tmp
    ))
    {
        dt = tmp;
    }
