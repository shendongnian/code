    for (int i = 0; i < answerList.Count; i++)
    {
         Button acceptButton = new Button { Content = "Lösung" };
         acceptButton.Click += (sender, args) => System.Windows.MessageBox.Show(i.toString());
         someList.Items.Add(acceptButton);
    }
