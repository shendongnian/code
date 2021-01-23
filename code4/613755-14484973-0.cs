    protected override void OnFormClosing(FormClosingEventArgs e)
    {
      switch (e.CloseReason)
      {
        case CloseReason.UserClosing:
          if (MessageBox.Show("Do you want to exit the application?", "Your App", MessageBoxButtons.YesNo) == DialogResult.No)
          {
            e.Cancel = true;
          }
          break;
        case CloseReason.WindowsShutDown:
          e.Cancel = false; //this is propably dumb
          break;
        default:
          break;
        }
      base.OnFormClosing(e);
    }
