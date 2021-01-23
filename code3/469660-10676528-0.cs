    public void SimulateTextInput(Form1 mainForm, string attName, string attValue)
    {
       //Form1 mainForm = new Form1();
       if(mainForm == null)
            throw new ArgumentNullException("mainForm");
       HtmlElementCollection col = mainForm.webBrowser1.Document.GetElementsByTagName("input");
       foreach (HtmlElement element in col)
       {
          if (element.GetAttribute("name").Equals(attName))
          {
             element.SetAttribute("value", attValue);
          }
       }
