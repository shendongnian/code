    public class Listt< T, T1, T2>
        {
             public Listt()
            {
    
            }
            public void Add(T item, T1 item1, T2 item3)
            {
    
            }
        }
    
       
    public partial class MyApp : Window
    {
           
     public MyApp()
           
     {
              
      InitializeComponent();
    
         Listt<string, string, string> customList = new Listt<string, string, string>();
         customList.Add("we","are","here");
               
      }
    }
