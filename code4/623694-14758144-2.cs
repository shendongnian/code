    public void setText()
    {
        MyServer.BeginInvoke((Action) setTextOnUiThread);
    }
    private void setTextOnUiThread()
    {
        ServerClass bs = MyServer;
        Label lbl = bs.Controls["label1"] as Label;
        lbl.Text = "New Text";
    }
