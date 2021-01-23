            // On Search Button Click: RichTextBox ("rtb") will display all the words inside the document
        private void btn_Search_Click(object sender, EventArgs e)
        {
            try
            {
                if (rtb.Text != string.Empty)
                {// if the ritchtextbox is not empty; highlight the search criteria
                    int index = 0;
                    String temp = rtb.Text;
                    rtb.Text = "";
                    rtb.Text = temp;
                    while (index < rtb.Text.LastIndexOf(txt_Search.Text))
                    {
                        rtb.Find(txt_Search.Text, index, rtb.TextLength, RichTextBoxFinds.None);
                        rtb.SelectionBackColor = Color.Yellow;
                        index = rtb.Text.IndexOf(txt_Search.Text, index) + 1;
                        rtb.Select();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error"); }
        }
    }
}
