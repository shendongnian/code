    protected override void WndProc(ref Message message)
    {
        switch (message.Msg)
        {
          case 0x84: 
              message.Result = new IntPtr(0x2);
              return;
        }
        
        base.WndProc(ref message);
    }
