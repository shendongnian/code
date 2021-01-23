    void UIMethod()
    {
       try{  
           MethodBeforeFoo();
           var ret = Foo();
        }
       catch(Exception ex)
        {
           MessageBox.Show(ex.Message); 
        }
              
    }
