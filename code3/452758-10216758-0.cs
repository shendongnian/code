    List<string> list = new List<string>();
            list = (List<string>)Session["JobRole"];
            foreach (string item in list)
            {
                ListBox2.Items.Add(item);
            }
