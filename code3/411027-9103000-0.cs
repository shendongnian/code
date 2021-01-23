    string xml = @"
        <Details>
            <CreditCard cardnum='1234567890123456'
                        ccv='123' 
                        exp='0212' 
                        cardType='1' 
                        name='joe' />
        </Details>";
    XElement element = XElement.Parse(xml);
    IEnumerable<XElement> elementsWithPossibleCCNumbers =
        element.Descendants()
                .Where(d => d.Attributes()
                             .Select(a => a.Value)
                             .Any(v => v.Length >= 13 &&
                                       v.Length <= 16 &&
                                       v.All(Char.IsDigit)));
    foreach (var x in elementsWithPossibleCCNumbers)
    {
        foreach (var a in x.Attributes())
        {
            //Check if the value is a number
            if (a.Value.All(Char.IsDigit))
            {
                //Check if value is the credit card
                if (a.Value.Length >= 13 && a.Value.Length <= 16)
                    a.Value = new String('*', a.Value.Length - 4) + a.Value.Substring(a.Value.Length - 4);
                else //If value is not a credit card, replace it with ***
                    a.Value = "***";
            }
        }
    }
    xml = element.ToString();
