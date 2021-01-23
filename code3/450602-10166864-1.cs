      List<NumericUpDown> numUpDnList = new List<NumericUpDown>();
      for (int i = 0; i < 3; i++)
      {
        NumericUpDown numUpDn = new NumericUpDown();
        numUpDn.Location = new System.Drawing.Point(120, 275 + i * 19);
        numUpDn.Size = new System.Drawing.Size(50, 20);
        this.Controls.Add(numUpDn);
        numUpDnList.Add(numUpDn);
      }
      decimal total = numUpDnList.Sum(updn => updn.Value);
      labelScore.Text = total.ToString();
