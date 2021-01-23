    protected void btnGetValues_Click(object sender, EventArgs e)
    {
        Panel[] pnls = new Panel[3] { pnlAns, pnlA, pnlJ };
        ArrayList answers = new ArrayList();
        //Alternatively....
        System.Collections.Hashtable ht = new System.Collections.Hashtable();
    
        foreach (Panel pnlIn in pnls)
        {
            foreach( Control childControl in pnlIn.Controls )
            {
                if( childControl is TextBox )
                {
                    TextBox box = (TextBox)childControl;
                    //Retrieve and store value from childControl.Text
                    answers.Add(box.Text);
                    //Alternatively...
                    ht.Add( box.ID, box.Text );
                }
            }
        }
    }
