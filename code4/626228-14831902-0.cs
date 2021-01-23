        AdventureWorks2008R2Entities entities = null;
        try // Don't use using because it can cause race condition
        {
            entities = new AdventureWorks2008R2Entities();
            ...
        } finally {
        } 
