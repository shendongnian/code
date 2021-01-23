    Int32 value;
    Boolean result = Int32.TryParse(txt1.Text, out value);
    if (!result)
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
