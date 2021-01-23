    for (int i = 0; i < TheCount; i++) {
      int id = i + 1;
      Button button = GetButton(id);
      int count = chk.GetCount(2);
      if (count == -1) { 
        button.Visible = false;
      } else { 
        button.Text = String.Format("Next dep{0} [{1}]", id, count);
        if (count == 0) {
          button.Enabled = false;
        }
      }                   
    }
