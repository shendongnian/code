    for(int i = 1; i <= 7; i++)
    {
       Checkbox checkbox = MyParentPanel.Controls["chk" + i] as Checkbox;
       Label label = MyParentPanel.Controls["lab" + i] as Label;
       if(checkbox != null && label != null && !checkbox.Checked)
       {
          label.Text = rng.Next(1, 7).ToString();
       }
    }
