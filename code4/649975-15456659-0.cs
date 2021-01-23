    public class Connection
    {
        public event DataSent;
        public void OnDataSent()
        {
            if (DataSent != null) { OnDataSent(this, EventArgs.Empty); }
        }
        
        public void Send()
        {
             OnDataSent();
             //Then put your send code
        }
    }
    public class Program
    {
         public void CallingMethod()
         {
             Connection con = ne
         }
    }
