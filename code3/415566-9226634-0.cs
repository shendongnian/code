    public static void CleanNil(this XElement value)
    {
         var todelete = value.DescendantsAndSelf().Where(x => (bool?) x.Attribute("nil") == true);
         if(todelete.Any())
         {
            todelete.Remove();
         }
    }
