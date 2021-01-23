    private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
        {
            int r = dataGridView1.HitTest(e.X, e.Y).RowIndex + 1;
            ContextMenuStrip m = new ContextMenuStrip();
            globals.timer = r;
            m.Items.Add("Start");
            m.Items.Add("Stop");
            m.ItemClicked += new ToolStripItemClickedEventHandler(m_ItemClicked);
            m.Show(dataGridView1, new Point(e.X, e.Y));
        }
    }
    void m_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
    {
        switch (e.ClickedItem.Text)
        {
            case "Start":
                startTimer(globals.timer);
                break;
            case "Stop":
                stopTimer(globals.timer);
                break;
            default:
                break;
        }
    }
    private void startTimer(int t)
    {
        // code here to start timer t
    } 
    private void stopTimer(int t)
    {
        // code here to stop timer t
    }
    static class globals
    {
        public static int timer = 0;
    }
