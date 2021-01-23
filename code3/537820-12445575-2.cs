    class Form2 : Something
    {
      public event NotifySubscriberEventHandler NotifySubscriberEvent ;
       public void button_Click(object sender, EventArgs e)
       {
          var handler = NotifySubscriberEvent ;
          if( handler != null)
           {
              handler(this,EventArgs.Empty) ;
           } 
           
       } 
    } 
    
    class Form1 
    {
       public BindingList<T> MyBindingList {get;set;} //
       public void CreateForm2()
       {
           Form2 form2 = new Form2() ; 
           form2.NotifySubscriberEvent += OnButtonClicked;
    
       }
       public void OnButtonClicked(object source, EventArgs e)
       {
         //Do Something when notified
          MyBindingList.Add(...)
       }
    }
