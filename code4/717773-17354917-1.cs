    private void picRooms_Paint(object sender, PaintEventArgs e)
    {
        DrawComplete(e.Graphics)
    }
    public void Complete()
    {
        DrawComplete(this.CreateGraphics());
    }
