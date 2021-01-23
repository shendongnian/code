    delegate void UpdateGridThreadHandler(Reply reply);
    private void ping_PingCompleted(object sender, PingCompletedEventArgs e)
    {
        UpdateGridWithReply(e.Reply);
    }
    private void UpdateGridWithReply(Reply reply)
    {
        if (dataGridView1.InvokeRequired)
        {
            UpdateGridThreadHandler handler = UpdateGridWithReply;
            dataGridView1.BeginInvoke(handler, table);
        }
        else
        {
            DataGridViewRow row = this.current_row; 
            DataGridViewCell speed_cell = row.Cells["speed"];
            speed_cell.Value = reply.RoundtripTime;
        }
    }
