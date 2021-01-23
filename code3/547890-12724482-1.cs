            MessagePrompt messagePrompt = new MessagePrompt();
            messagePrompt.Message = "Some Message.";
            Button yesButton = new Button() { Content = "Yes" };
            yesButton .Click += new RoutedEventHandler(yesButton _Click);
            Button noButton = new Button() { Content = "No" };
            noButton .Click += new RoutedEventHandler(noButton _Click);
            messagePrompt.ActionPopUpButtons.Add(noButton);
            messagePrompt.ActionPopUpButtons.Add(yesButton );
            messagePrompt.Show();
