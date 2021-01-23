    public ActionResult ProcessActions(List<ActionType> allActions)
    {
        string xpathquery = "Options";
         
        foreach(var playerAction in allActions)
        {
            if(playerAction == ActionType.None)
               break;
            xpathquery += "/" + playerAction.ToString();
        }
        //Query xmldocument of all options
        var result = Singleton.ActionsDoc.SelectSingleNode(xpathquery);
        string attackRes = result.InnerXml;
        XmlSerializer serializer = new XmlSerializer(typeof(ActionResult))
        //Might need to prepend something to attackRes before deserializing, none of this is tested
        byte[] allBytes = Encoding.UTF8.GetBytes(attackRes);
        MemoryStream ms = new MemoryStream(allBytes);
        ActionResult result = (ActionResult)serializer.Deserialize(ms);
        return result;
    }
