    for (var i = 0; i < datagridview1.Count; i++)
    {
        if ((bool)datagridview1[0, i])
            {
                datagridview1[0, i] = new DataGridViewTextBoxCell
                {
                            Style = { ForeColor = Color.Transparent, 
                                      SelectionForeColor = Color.Transparent }
                };
            }
    }
