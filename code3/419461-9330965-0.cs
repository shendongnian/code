            string curNamespace = string.Empty; // or whatever
            try
            {
                curNamespace = "name";
            }
            catch (Exception e)
            {
                throw new Exception("Error reading " + curNamespace, e);
            }
