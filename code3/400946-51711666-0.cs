    private void CloseSerialOnExit()
    {
        try
        {
            serialPort1.DtrEnable = false;
            serialPort1.RtsEnable = false;
            serialPort1.DiscardInBuffer();
            serialPort1.DiscardOutBuffer();
            serialPort1.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
