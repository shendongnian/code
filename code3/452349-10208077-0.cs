           //Purge old database                  
        foreach (Property a in entities.Properties)
        {
            if (a != null)
            {
                if (a.Images != null)
                {
                    foreach (Image i in a.Images)
                    {
                        entities.Images.DeleteObject(i);
                    }
                }
                entities.Properties.DeleteObject(a);
            }
            
        }
        entities.SaveChanges();
