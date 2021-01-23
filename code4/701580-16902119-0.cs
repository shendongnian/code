    Dictionary<string, string> values = new Dictionary<string,string> {
        { "@CONTACT", txtContact.Text.ToUpper() },
        { "@ADDR1", txtAddress1.Text.ToUpper() },
        // etc
    };
    var enteredParams = values.Where(kvp => !string.IsNullOrEmpty(kvp.Value));
 
