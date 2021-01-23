            private void OnSubmitClick(object sender, RoutedEventArgs e)
        {
            XElement xe = XElement.Load(new XmlNodeReader(DataProvider.Document));
            var elements = xe.Elements("ContactMethods").Elements("ContactMethod").ToList();
            var sel = combobox1.SelectedValue;
            foreach(XElement element in elements)
            {
                element.SetAttributeValue("Selected", (string)sel == element.Value);
            }
            xe.Save("datacontext.xml");
            //DataProvider.Document.Save("datacontext.xml");
        }
