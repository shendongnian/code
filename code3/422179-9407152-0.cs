    public class Form1
    {
      public decimal Total {get; set;}
    }
    
    public class Form2
    {
      public Form2()
      {
        var form1 = new Form1();
        form1.Show();
    
        ..later, after use has done some work and you need the variable
        var total = form1.Total;
      }
    }
