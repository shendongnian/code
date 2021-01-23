    void UIMethod()
    {
       try{  
           var ret = Foo();
        }
       catch(Exception ex)
        {
           MessageBox.Show(ex.Message); 
        }
              
    }
