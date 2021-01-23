      public void ClearButtons()
      {
        for (int i = 0; i < this.Controls.Count; i++)
        {
           if (Controls[i] is Button)
           {
             Controls.RemoveAt(i);
             i--;
           }
        }
      }
