    private void TestTextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
            string temp = TestTextBox.Text;
            if (temp.Length > 10)
            {
                char[] charArray=temp.ToCharArray();
                temp = new string(charArray, 0, 10);
                temp += "...";
            }
            TestTextBox.Text = temp;
    }
