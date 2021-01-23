    //Save your counter in Viewstate or InputHidden in order to persist
    public int Counter 
    {
        get
        {
            int s = (int)ViewState["Counter"];
            return (s == null) ? 0 : s;
        }
        set
        {
            ViewState["Counter"] = value;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Counter = Counter + 1;
 
        if (Counter > 1)
        {
            Button1.Text = "Selected";
            Button1.BackColor = System.Drawing.Color.DarkGreen;
            Button2.Text = "Selected";
            Button2.BackColor = System.Drawing.Color.DarkGreen;
            startingTime.Text = "9AM";
            endingTime.Text = "11AM";
        }
    
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please select one slot only');", true);
        }
    }
