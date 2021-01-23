    public class Form2
    {
      public bool confirm { get; set; }
        public Form2()
            {
                confirm = false;
                InitializeComponent(); 
            }
       private void Confirm_Button_Click(object sender, RoutedEventArgs e)
        {
           //your code
           confirm = true;
           this.Close();
        }
    }
