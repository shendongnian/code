    List<String> TextList = new List<string>();
            foreach (var item in Controls)
            {
                if (item is TextBox)
                {
                    TextList.Add(((TextBox)item).Text);
                }
            }
