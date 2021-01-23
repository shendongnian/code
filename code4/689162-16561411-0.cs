    // class with all data you want to use to update GUI controls
    class MyData
    {
       public string Text1 { get; set; }
       public string Text2 { get; set; }
       ...
    }
    
    // class which obtains data from a DB
    class DBClient
    {
       MyForm myForm;
    
       DBClient(MyForm myForm)
       {
           this.myForm = myForm; // you're just passing a reference to MyForm here, you're not creating a new object
       }
    
       void UpdateFormControls()
       {
           MyData data = ...; // fill it with data obtained from from DB 
           myForm.UpdateControls(data);
       }
    }
    
    // your custom form containing various controls
    class MyForm : Form
    {
       DBClient dbClient;
       
       MyForm()
       {
          dbClient = new DBClient(this);
       }
    
       public void UpdateControls(MyData data)
       {
          if (InvokeRequired)
          {
             this.BeginInvoke((MethodInvoker) delegate { UpdateControls(data); });
             return;
          }
    
          control1.Text = data.Text1;
          control2.Text = data.Text2;
          ...
       }   
    }
