     foreach (Control c in Panel1.Controls)
           {
                    c.Click += SpotChosen;
           }
     private void SpotChosen(object sender, EventArgs e)
          {
              var label = sender as Label;
              
          }
