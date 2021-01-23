    public class X 
    {
        private static bool isClosingHandled = false;
        public static void HandleClose()
        {
            //// app closing logic
            isClosingHandled = true;
        }
    }
    private void Window_Closing_1(object sender, CancelEventArgs e)
    {
        X.HandleClose();   
    }
