        string name = "Mr and Mrs Smith";
        string[] titles = new string[] {"Mr", "Miss", "Mrs", "Ms", "Master", "Mr and Mrs", "Mr & Mrs", "Lady", "Lord", "Prof", "Proffessor", "Ma'am", "Madame"};
        bool foundTitle = false;
        foreach (string title in titles)
        {
            if (name.StartsWith(title) && !name.Equals(title, StringComparison.CurrentCultureIgnoreCase))
            {
                var titleLength = title.Length;
                var titlelessName = name.Substring(titleLength + 1);
                var spaceIndex = titlelessName.IndexOf(' ');
                if (spaceIndex > -1 && spaceIndex >= 0)
                {
                    var firstName = titlelessName.Substring(0, spaceIndex);
                    var lastName = titlelessName.Substring(spaceIndex + 1);
                    txtFname.Text = firstName;
                    txtLname.Text = lastName;
                }
                foundTitle = true;
                break;
            }
        }
        if (!foundTitle && name.Contains(' '))
        {
            var firstName = name.Substring(0, name.IndexOf(' '));
            var lastName = name.Substring(name.IndexOf(' '));
            txtFname.Text = firstName;
            txtLname.Text = lastName;
        }
