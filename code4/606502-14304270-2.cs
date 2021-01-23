    if (txt1.Text.Trim().Length > 0)
    {
        // Parse the value only once as it can be quite performance expensive.
        Int32 value = Int32.Parse(txt1.Text)
        if ((value >= 2) && (value <= 10))
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
