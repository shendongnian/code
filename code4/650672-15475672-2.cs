    private int _deleteCount = 0;
    private bool _deleting = false;
    private bool _reallyDelete = false;
    private IEnumerable<object> _deleteEntities = null;
    private void Grid_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
    {
        DataGridView grid = (DataGridView)sender;
        if (!_deleting)
        {
            _deleting = true;
            _deleteCount = grid.SelectedRows.Count;
            _deleteEntities = grid.SelectedRows.Cast<DataGridViewRow>().Select(r => r.DataBoundItem).ToList();
            string msg = "";
            string title = "";
            switch (this.Type)
            {
                case AdminType.Channel:
                    msg = string.Format("Do you really want to delete {0}?", _deleteCount == 1 ? "this channel" : "these channels");
                    title = _deleteCount == 1 ? "Delete channel" : "Delete channels";
                    break;
                // other types ...
                default:
                    break;
            }
            _reallyDelete = MessageBox.Show(msg, title, MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes;
        }
        e.Cancel = !_reallyDelete;
        // wait until all events are triggered before starting to delete
        if (--_deleteCount == 0)
        {
            switch (this.Type)
            {
                case AdminType.Channel:
                    List<Channel> channels = _deleteEntities.Cast<Channel>().ToList();
                    Delete_Channels(channels);
                    break;
                // other types ...
                default:
                    break;
            }
            _deleting = false;
            _reallyDelete = false;
            _deleteEntities = null;
        }
    }
