    public static class MyExtension
    {
        public static void Validate(this TextBox myTextBox, string correctText, string error)
        {
            if(myTextBox.Text != correctText)
                Console.WriteLine(string.Format("{0} [{1} == '{2}']", error, myTextBox.Name, myTextBox.Text));
        }
    }
