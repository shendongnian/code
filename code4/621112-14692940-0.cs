    protected override void WndProc(ref Message m) {
      //0x210 is WM_PARENTNOTIFY
      if (m.Msg == 0x210 && m.WParam.ToInt32() == 513)    //513 is WM_LBUTTONCLICK
        {
        Console.WriteLine("## MouseClick on UserControl1 ");
        this.BeginInvoke(new Action(() => UserControlClicked(this, new EventArgs())));
        return;
      }
      /*
      else if (m.Msg == 0x2a1) // WM_MOUSEHOVER
          TTrace.Debug.Send("## WMsg " + m.Msg + " / WParam " + m.WParam.ToInt32());
      */
      base.WndProc(ref m);
    }
