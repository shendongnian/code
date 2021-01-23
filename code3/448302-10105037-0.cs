    public static class MyExtension
    {
        public static void SetError(this TextBox myTextBox, string correctText, string error)
        {
            if(myTextBox.Text != correctText)
                Console.WriteLine(error + myTextBox.Name);
        }
    }
