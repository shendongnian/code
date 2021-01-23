    private void btnStartSingleHost_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < 500; i++)
            new System.Threading.Thread(establishConnection).Start(i);
    }
    private void establishConnection(object state)
    {
        int i = (int)state;
        // do whatever you want with i here
        new SinglePortScan(tbHostIP.Text, int.Parse(nupdHostPort.Value.ToString()), int.Parse(nupdHostTimeout.Value.ToString()), ref tbSingleResults).connect();
    }
