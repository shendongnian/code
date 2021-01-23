    for (int i = 0; i < panel1.Controls.Count; i++)
    {                
      Control c = panel1.Controls[i];
      lastChar = c.Name[c.Name.Length - 1];
      lastValue = (int)Char.GetNumericValue(lastChar);
      MessageBox.Show("second " + c.Name);
    
      if (lastValue > 0 && lastValue < count)
      {
        panel1.Controls.Remove(c);
        c.Dispose();
        i--;
      }
     }
