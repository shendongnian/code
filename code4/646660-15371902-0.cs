    while (textReader.Read())
        {
            textReader.MoveToElement();
            type = textReader.NodeType;
            if (type == XmlNodeType.Element)
            {
                textReader.Read();
                switch( textReader.Name )
                {
                   case "Code":
                      code = textReader.Value;
                      break;
                   case "Name":
                      name = textReader.Value;
                      break;
                   //SNIP
                   case "Info":
                      info = textReader.Value;
                      module.Add(new modules(name, code, semester, tSlot, lSlot, info, preReq));
                      break;
                   default:
                      //Whatever you do here
                      break;
                 }
                 Console.WriteLine(textReader.Value);
            }
            foreach (object o in module)
            {
                modules m = (modules)o;
                String hold = m.mName;
                selectionBox.Items.Add(hold);
            }
        }
