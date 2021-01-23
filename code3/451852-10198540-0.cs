    public static IE CheckForBrowser()
            {
                IE Window;
    
                if (Browser.Exists<IE>(Find.ByTitle("My Site!")) == true)
                {
                    Window = IE.AttachTo<IE>(Find.ByUrl("http://www.mysite.com"));
                }
                else
                {
                    Window = new IE("http://www.mysite.com");
                }
    
                return Window;
            }
