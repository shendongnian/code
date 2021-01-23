    Ping ping = new Ping();
    for(int i = 0; i<= number_of_pings; i++)
    {
        PingReply pingReply = ping.Send(address_to_send);
        dataGridView1.Rows.Add(address_to_send, pingReply.Address, pingReply.RoundtripTime, pingReply.Status);
        dataGridView1.PerformLayout();
        Application.DoEvents();
    }
