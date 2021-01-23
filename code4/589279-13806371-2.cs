    foreach (var item in form1.Controls)
            {
                if (item is Button)
                {
                    if (((Button)item).BackColor == Color.Red)
                    {
                        ((Button)item).BackColor = Color.Yellow;
                    }
                }
            }
