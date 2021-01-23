    foreach (Control c in yourForm.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Clear();
                }
           }
