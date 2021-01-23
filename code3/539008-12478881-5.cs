    btn_Click(object sender, EventArgs e)                           
    {                           
        HandlePayGrade();                  
        HandleSecondList();
        HandleThirdList();
    }   
    public void HandlePayGrade()
    {
        SortedList<int, string> paygrades = new SortedList<int, string>();                               
        populatePaygrades(paygrades, sqlconnection);       
        DoStuffWithPaygrades(paygrades);
    }
