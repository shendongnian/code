    foreach(var xmlNode in nodes)
    {
        try    
        {
           //
           int valor = Convert.ToInt32(xmlNode.ChildNodes.Item(2).InnerText.Trim());
           // A Lot of another validations here
        }
        catch(Exception e)
        {
           LogInformation(e.Message); // current item is xmlNode
           return;
        }
    }
