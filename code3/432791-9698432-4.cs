            StringBuilder markupBuilder = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(markupBuilder);
            System.Windows.Markup.XamlDesignerSerializationManager manager = 
                new System.Windows.Markup.XamlDesignerSerializationManager(writer);
            manager.XamlWriterMode = System.Windows.Markup.XamlWriterMode.Value;
            
            // data grid named dataGrid1
            var template = dataGrid1.Template;
            System.Windows.Markup.XamlWriter.Save(dataGrid1.Template, manager);
            string markup = markupBuilder.ToString();
