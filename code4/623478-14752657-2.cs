     IEnumerable<RadioButton> buttons = grbFiltro.Controls.OfType<RadioButton>();
        foreach (var Button in buttons)
        {
             if (Button.Checked)
             {
                 //Do Something
             }
         }
