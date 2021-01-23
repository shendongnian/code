    // add this to the top of the file containing your class
    using mshtml;
    public void SetDefaultValue(string ControlID, string ControlValue)
    {
        System.Windows.Forms.HtmlDocument doc = webBrowser1.Document;
        IHTMLDocument2 document = doc.DomDocument as IHTMLDocument2;
        var sel = doc.GetElementById(ControlID);
        HTMLSelectElement domSelect = (HTMLSelectElement)sel.DomElement;
        domSelect.options.length = 0;
        HTMLOptionElement option;
        // here you can dynamically add the options to the select element
        for (int i = 0; i < 10; i++)
        {
            option = (HTMLOptionElement)document.createElement("option");
            option.text = String.Format("text{0}", i);
            option.value = String.Format("value{0}", i);
            domSelect.options.add(option, 0);
        }
    }
