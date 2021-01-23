    private void askBtn_Click(object sender, EventArgs e)
    {
     sqlQuestion = sqlQuestiontF.Text;
     username = initialTf.Text;
     adress = adressTf.Text;
    
     connect conn = new connect();
     conn.myConnection(username, adress);
    
     conn.askSQL(sqlQuestion);
    }
