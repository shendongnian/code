            List<XElement> list = Xdoc.Descendants("User").Where(el => el.Attribute("UserId").Value == txtUserName.Text).ToList();
            if (list.Count == 0)
            {
                // Add new node
            }
            else
            {
                // Modify the existing node
            }
