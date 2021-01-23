        foreach (Control objControl in this.Controls)
        {
            if (objControl is Button)
            {
                (objControl as Button).BackColor = Color.DarkGreen;
            }
        }
