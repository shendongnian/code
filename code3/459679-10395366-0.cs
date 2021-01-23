    private static void OnRowUpdating(object sender, SqlRowUpdatingEventArgs e)
    {
    string MyERowValu = e.Row["sl_no"].ToString().Trim();
    if (e.Row["itm_description"].ToString().Trim().Length == 0)
    {
    //e.Status = UpdateStatus.SkipCurrentRow;
    e.Status = UpdateStatus.SkipAllRemainingRows;
    }
    }
