    public class ClassWithYourCode
    {
        public TextBox TextBoxToUpdate { get; set; }
        Action<string> updateTextBoxDelegate;
        public ClassWithYourCode()
        { }
        public void methodToExecute()
        {
            bool IsDone = false;
            while (!IsDone)
            {
                // write your code here. When you need to update the 
                // textbox, call the function:
                // updateTextBox("message you want to send");
                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(1000);
                    updateTextBox(string.Format("Iteration number: {0}", i));
                }
                IsDone = true;
            }
            updateTextBox("End of method execution!");
        }
        private void updateTextBox(string MessageToShow)
        {
            if (TextBoxToUpdate.InvokeRequired)
            {
                updateTextBoxDelegate = msgToShow => updateTextBox(msgToShow);
                TextBoxToUpdate.Invoke(updateTextBoxDelegate, MessageToShow);
            }
            else
            {
                TextBoxToUpdate.Text += string.Format("{0}{1}", MessageToShow, Environment.NewLine);
            }
        }
    }
