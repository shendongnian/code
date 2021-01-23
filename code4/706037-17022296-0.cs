    // Control holding the search form
    public class MySearchControl : UserControl {    ...   }
    
    // Form to read data from the search form
    public class MyFormForReadingSearchControl : Form
    {    
       // Constructor is as normal
    
       public MySearchControl SearchControl { get; set; } 
    }
    
    // Form to send the search data.
    public class MyForForSendingTheSearchControl : Form
    {    
       public MySearchControl SearchControl { get; set; }
    
       protected void searchControl_Click(object sender, EventArgs e)    
       {
          var newForm = new MyFormForReadingSearchControl();
          newForm.SearchControl = this.SearchControl; // Pass via property
          newForm.Show();    
       }
    }
