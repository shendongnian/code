    if (txt1.Text.Trim().Length > 0)
    {
        Int32 value;
        if (!Int32.TryParse(txt1.Text, out value))
        {
            l6.ForeColor = Color.Red;
            l6.Text = "Svp choisir un nombre entre 2 et 10 ... Soyez Logique!";
            // Clear the text...
            txt1.Text = "";
        }
        else
        {
            // Your code here...
        }
    }
