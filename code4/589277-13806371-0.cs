    foreach (var item in Page.Controls)
            {
                if (item is Button)
                {
                    if(((Button)item).BackColor == Color.Red)
                      {
                        Button.BackColor = Color.Red;
                      }
                }
            }
