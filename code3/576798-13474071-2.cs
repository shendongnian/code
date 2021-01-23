    void DisplayOutput()
        {
            ApplicationDataCompositeValue composite = (ApplicationDataCompositeValue)roamingSettings.Values["classperson"];
            if (composite == null)
            {
                // "Composite Setting: <empty>";
            }
            else
            {
            Peopleobj.PersonID = composite["PersonID"] ;
            Peopleobj.PersonName = composite["PersonName"];
            }
             }
