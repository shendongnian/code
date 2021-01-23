    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                throw new Exception("Oops, somthing bad happened!"); //This is line 17
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                //throw; //If you don't have this the code will continue executing after this point.
            }
        }
    }
