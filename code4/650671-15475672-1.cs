    private int _deleteCount = 0;
    private bool _deleting = false;
    private void Grid_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
    {
        DataGridView grid = null;
        switch (this.Type)
        {
            case AdminType.Channel:
                grid = GrdChannel;
                break;
            // other types ...
            default:
                break;
        }
        if (!_deleting)
        {
            _deleting = true;
            _deleteCount = grid.SelectedRows.Count;
        }
        // wait until all events are triggered before we start to delete
        if (--_deleteCount == 0)
        {
            _deleting = false;
            switch (this.Type)
            {
                case AdminType.Channel:
                    List<Channel> channels = grid.SelectedRows.Cast<DataGridViewRow>()
                      .Select(row => (Channel)row.DataBoundItem).ToList();
                    e.Cancel = !Delete_Channels(channels);
                    break;
                // other types ...
                default:
                    break;
            }
        }
    }
