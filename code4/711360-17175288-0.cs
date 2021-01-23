            User = UsernametextBox.Text; //
            pass = PasswordtextBox.Text;
            if (ValidateFunction(User,pass))
            {new Dashboard().Show();}
            else
            {
                new NewQuote().Show();
            }
