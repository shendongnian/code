     //preventing direct assignment
     private myDelegate del;
    
            public void AddCallback(myDelegate m){
                del += m;
            }
    
            public void RemoveCallback(myDelegate m){
                del -= m;
            }
