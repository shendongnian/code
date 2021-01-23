    string test = item.FirstName.ToString();
        string test_add = ""; //creating an empty variable
        if(test.Length == 0) //situation where we have an empty instance
        {
            test_add = "0";
        }
        else
        {
            test_add = test.Substring(0, 2);
        }
