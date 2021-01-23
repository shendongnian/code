    public object ColorBeingReturned(string textFromBox)
    {
         var color = dfault(Color);
         textVsColor.TryGetValue(textFromBox, out color); 
         return color;
    }
