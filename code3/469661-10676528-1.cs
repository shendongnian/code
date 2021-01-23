    class InputSimulator
    {
        Form1 mainForm = null;
        public InputSimulator(Form1 inputForm)
        {
            if (inputForm == null)
                throw new ArgumentNullException("inputForm");
            mainForm = inputForm;
        }
        public void SimulateTextInput(string attName, string attValue)
        {
            HtmlElementCollection col = mainForm.webBrowser1.Document.GetElementsByTagName("input");
            foreach (HtmlElement element in col)
            {
                if (element.GetAttribute("name").Equals(attName))
                {
                    element.SetAttribute("value", attValue);
                }
            }
        }
        public void SimulateButtonClick(string attName)
        {
            HtmlElementCollection col = mainForm.webBrowser1.Document.GetElementsByTagName("input");
            foreach (HtmlElement element in col)
            {
                if (element.GetAttribute("value").Equals(attName))
                {
                    element.InvokeMember("click");
                }
            }
        }
    }
