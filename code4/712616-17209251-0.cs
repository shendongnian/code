    for (int i = 0; i < answerList.Count; i++)
    {
        var acceptButton = new Button { Content = "Lösung" };
        acceptButton.Click += (s, e) => MessageBox.Show(i.ToString());
        someList.Items.Add(acceptButton);
    }
