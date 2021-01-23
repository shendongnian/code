    // field to keep CancellationTokenSource:
    CancellationTokenSource m_cts;
    // in your method:
    m_cts = new CancellationTokenSource();
    foreach (DataGridViewRow dgvRow in dataGridView1.Rows)
    {
        Class h = new Class(dgvRow.Cells["name"].Value.ToString());
    
        Thread trdmyClass = new Thread(() => h.SeeInfoAboutName(m_cts.Token));
        trdmyClass.IsBackground = true;
        trdmyClass.Start();
    }
    //somewhere else, where you want to cancel the threads:
    m_cts.Cancel();
    // the SeeInfoAboutName() method
    public void SeeInfoAboutName(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            // do some work
        }
    }
