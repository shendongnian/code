    public void exam()
        {
            var ie = new IE();
            ie.GoTo("http://search.yahoo.com");
            ie.WaitForComplete();            
            if (ie.ContainsText("This page cannot be displayed"))
            {
                ie.Refresh();
            }
        }
