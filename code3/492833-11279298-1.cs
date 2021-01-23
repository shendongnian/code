      List<Control> controls = Controls.OfType<TextBox>().Cast<Control>().ToList();
      foreach (Control m in controls)
      {
          if (m.Font.Bold)
          {
              m.Font = new Font(m.Font, FontStyle.Underline);
          }
          else
          {
               m.Font = new Font(m.Font, FontStyle.Bold);
               m.Font = new Font(m.Font, FontStyle.Underline);
          }
    
      }
