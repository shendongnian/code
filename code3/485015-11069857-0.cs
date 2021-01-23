            bool error = false;
            if (_Text.Length < 1)
            {
                error = true;
                return error;
            }
                if (Name == "textbox1" && _Text.Length == 1)
                {
                    if (!Regex.IsMatch(_Text, "^[0-9\\s]"))
                    {
                        MessageBox.Show("Only Number and Space!");
                        error = true;
                    }
                }
                if (Name == "textbox2" && _Text.Length==1)
                {
                    if (!Regex.IsMatch(_Text, "^[a-zA-z]"))
                        {
                            MessageBox.Show("Only Character!");
                            error = true;
                        }
                 }
           // textbo3 ... textbox17
    return error;
  }
