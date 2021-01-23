    public Form1()
    {
      // ...
      axWindowsMediaPlayer1.PositionChange += axWindowsMediaPlayer1_PositionChange;
    }
    void axWindowsMediaPlayer1_PositionChange(object sender, AxWMPLib._WMPOCXEvents_PositionChangeEvent e)
    {
      MessageBox.Show("The user changed the position from " + e.oldPosition + " to " + e.newPosition);
    }
