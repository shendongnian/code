            XmlReader reader = XmlReader.Create("books.xml");
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element: // The node is an element.
                        //DO NOTHING
                        break;
                    case XmlNodeType.Text: //Display the text in each element.
                        //label.Text = reader.Value;
                        Label l = new Label();
                        System.Drawing.Point l1 = new System.Drawing.Point(15, 13 + a);
                        l.Location = l1;
                        l.Text = reader.Value;
                        a += 20;
                        break;
                    case XmlNodeType.EndElement: //Display the end of the element.
                        //DO NOTHING
                        break;
                }
            }
