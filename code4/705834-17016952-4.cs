      public void PasteText()
      {
         rtbChild.Text = Clipboard.GetText(); // this one simulates the rtb.Paste()
      }
      public void CopyText()
      {
         rtb.Copy(); 
      }
