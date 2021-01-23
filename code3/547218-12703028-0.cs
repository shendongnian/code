        String text = Richtextbox.Text.Replace(ReplaceOldWord, ReplaceNewWord);
        if(RichTextBox.Text != text)
        {
            Richtextbox.Text = text;
            DoSomething();
        }
