      List<Control> controls = Controls.OfType<TextBox>().Cast<Control>().ToList();
      foreach (Control m in controls)
      {
          if (m.Font.Underline)
          {
             m.Font = new Font(m.Font, FontStyle.Regular);
          }
          else
          {
              m.Font = new Font(m.Font, FontStyle.Underline);
          }
    
      }
