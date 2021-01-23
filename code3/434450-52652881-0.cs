        string stringToBool1 = "true";
        string stringToBool2 = "1";
        bool value1;
        if(bool.TryParse(stringToBool1, out value1))
        {
            MessageBox.Show(stringToBool1 + " is Boolean");
        }
        else
        {
            MessageBox.Show(stringToBool1 + " is not Boolean");
        }
