    public class Mail 
    {
        public Form form { get; set; }
        public Mail(Form  f)
        {
            form = f;
        }
    
        private void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            // your code 
            // finally close the form
            form.Close();
        }
    }
