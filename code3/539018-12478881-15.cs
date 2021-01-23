    btn_Click(object sender, EventArgs e)                           
    {   
        //this is simpler yet, separates the concerns of each type of list.                        
        HandlePayGrade();                  
        HandleSecondList();
        HandleThirdList();
    }   
    public void HandlePayGrade()
    {
        // you are still separating your data access and processing concerns here.
        SortedList<int, string> paygrades = new SortedList<int, string>();                               
        populatePaygrades(paygrades, sqlconnection);       
        DoStuffWithPaygrades(paygrades);
    }
