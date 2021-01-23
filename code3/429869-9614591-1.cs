    XDocument doc = new XDocument(
        new XDeclaration("1.0", "utf-8", "yes"),
        new XComment(""),
        new XElement("Snacks",
        trashFoods.Select(snack => GetSnackChildren(snack)
        )
    );
    …
    IEnumerable<XElement> GetSnackChildren(Snack snack)
    {
        yield return new XElement("Type", snack.Type);
        if(snack.Type == "Doritos")
        {
            yield return new XElement("GotSauce", snack.Sauce);
        }
        yield return new XElement("Name", snack.Name);
    }
