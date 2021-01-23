    public bool PreFilterMessage(ref Message m)
    {
      if (m.Msg == WM_MOUSEWHEEL)
      {
        SendMessage(panel1.Handle, m.Msg, m.WParam, m.LParam);
        return true;
      }
      return false;
    }
