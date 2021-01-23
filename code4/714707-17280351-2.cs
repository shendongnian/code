    //These are extension methods and must be in a static class
    //Will only work if Doc is saved at least once (has full name) - if document is new, the name will be 
    public static Document GetAsAppServicesDoc(this IAcadDocument Doc)
        {
            return Application.DocumentManager.OfType<Document>().First(D => D.Name == Doc.FullOrNewName());
        }
-------------
     public static string FullOrNewName(this IAcadDocument Doc)
        {
            if (Doc.FullName == "")
                return Doc.Name;
            else
                return Doc.FullName;
        }
