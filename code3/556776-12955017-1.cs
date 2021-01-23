    Control errorControl =null;
    foreach (Control ctrl in this.Controls)
    {
      if (ctrl is TextBox)
      {
        if (ctrl.Name == "MatricNoText")
        {
          if ((int.Parse(MatricNoText.Text) < 10000 || int.Parse(MatricNoText.Text) > 99999))
              {
                errorControl = ctrl;
              }
         }
         else if (ctrl.Name == "MatricNoText")
         {
           if (int.Parse(YearMarkText.Text) < 0 || int.Parse(YearMarkText.Text) > 100)
           {
             errorControl = ctrl;
            }
          }
          else
          {
            if (ctrl.Text.Length == 0)
            {
              errorControl = ctrl;
             }
           }
        }
      }
    MessageBox.Show("Please check your input." + errorControl.Focus());
