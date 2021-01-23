    private async void button2_Click(object sender, EventArgs e)
    {
    	DataTable dtMessages = await getMessages2(string sqlConn2, nMessage);
    }
    public async Task<DataTable> getMessages2(string sqlConn, int n)
    {
    	//create your query and command
    	var o = await cmd2.ExecuteReaderAsync();DataTable dtMessages = o;return dtMessages;
    }
