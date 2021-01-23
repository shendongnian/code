    private void dataGrid1_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
    {
    Compte Compte = e.Row.DataContext as Compte;
    if (Compte  != null)
    {
       // Verifs
    }
    }
