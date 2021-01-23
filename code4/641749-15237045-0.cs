    private void label1_MouseHover(object sender, EventArgs e)
    {
      // get text by mouse-over
      string textOfTheLabel = ((Label) sender).Text;
      string translatedText = GetTranslationFromDB(textOfTheLabel);
      
      // tooltip
      System.Windows.Forms.ToolTip toolTip1 = new System.Windows.Forms.ToolTip();
      toolTip1.SetToolTip((Label) sender, translatedText);
    }
