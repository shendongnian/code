        public void yeni()
        {
           //....
           RichTextBox rtb = new RichTextBox();
           rtb.Name = "richTextBox" + selectedTabPageIndex.ToString();
           rtb.TextChanged += rtb_TextChanged;
            //....    
         }
 
         void rtb_TextChanged(object sender, EventArgs e)
         {
              RichTextBox rtb = (RichTextBox)sender;
    
              if (rtb.Name == "richTextBox" + selectedTabPageIndex.ToString())
              {
                  //rtb is selected page richtextbox
                  //......
              }
          }
