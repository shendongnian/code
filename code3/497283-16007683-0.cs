    string delimiter = "|";
    string newLine = Environment.NewLine;
    using (mCustDataContext = new CustDataContext()) {
        var props = typeof(Customer).GetProperties();
        StringBuilder headers = new StringBuilder(string.Join(delimiter, props.Select(c => c.Name).ToArray()) + newLine);
        Func<Customer, string> myFunc = c => 
             string.Join(delimiter, props.Select(b => b.GetValue(c,null))) + newLine;
        var query = mCustDataContext.Customers.Select(myFunc);
                    
        foreach(var q in query)
            headers.Append(q);
        File.WriteAllText(yourFileName, headers.ToString(), mEncoding);
    }
