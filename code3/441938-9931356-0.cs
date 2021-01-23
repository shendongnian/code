    public void polulateSpecs(int itemID, List<neItem> coll)
    {
        Program p = new Program();
        for (int i = 0; i < coll.Count - 1; i++) // going over all Objects in the list
        {
            string CatName = coll[i].specCat.Trim(); // define the name of the category
            string queryCategoryCheck = "SELECT ID FROM ATTRIBUTE_CATEGORY WHERE ATTRIBUTE_NAME = '" + CatName + "'"; //check if Cat Exist query
            string queryCategoryInsert = "INSERT INTO ATTRIBUTE_CATEGORY(ATTRIBUTE_NAME) VALUES ('" + CatName + "')"; //insert new category query
            int cdId = 0; //Category ID holder
            string CID = p.querySQLStringReturn(queryCategoryCheck); //get ID
            int.TryParse(CID, ref cdId); //parse ID to number
            if (cdId == 0) //if value is 0, then no brand exists, therefore create one:
            {
                p.insertSQL(queryCategoryInsert, "Insert New Category " + CatName);
            }
            // Now Category should be in the database - get its ID
            string CID = p.querySQLStringReturn(queryCategoryCheck);
            int.TryParse(CID, ref cdId); // Category ID
            for (int c = 2; c < coll[i].attributesList.Count; c += 2)
            {
                string attname = coll[i].attributesList[c].Trim(); // Name of the attribute
                string attSpec = coll[i].attributesList[c - 1].Trim(); // Description of the attribute
                string queryAttributeCheck = "SELECT ID FROM ATTRIBUTE_LIST WHERE ATT_NAME = '" + attname + "' AND ATT_SPEC = '" + attSpec + "'"; // Query to check if attribute exists
                string queryAttributeInsert = "INSERT INTO ATTRIBUTE_LIST(PARENT_CAT, ATT_NAME, ATT_SPEC) VALUES (" + cdId + ", '" + attname + "', '" + attSpec + "')"; // Query to insert new category
                int aId = 0; // Attribute ID holder
                string AID = p.querySQLStringReturn(queryAttributeCheck); // get ID
                int.TryParse(AID, ref aId); // parse ID to number
                if (aId == 0) // if value is 0, then no bran exist, therefore create one
                {
                    p.insertSQL(queryAttributeInsert, "Insert New Attribute Set " + attname);
                }
                // now Category should be in the database - get its ID
                string AID = p.querySQLStringReturn(queryAttributeCheck);
                int.TryParse(AID, ref aId); // Attribute ID
            }
            // Add final record to database (Item ID and Corresponding Attribute category)
            string queryProductToAttributeCheck = "SELECT ID FROM PRODUCT_TO_ATT_CATEGORY WHERE PROD_ID = '" + itemID + "' AND ATT_CAT = '" + cdId + "'"; // check if Attribute Exist query
            string queryProductToAttributeInsert = "INSERT INTO PRODUCT_TO_ATT_CATEGORY(PROD_ID, ATT_CAT) VALUES (" + itemID + ", " + cdId + ")"; // insert new category query                
            int ptaID = 0; // Attribute ID holder
            string PTAID = p.querySQLStringReturn(queryProductToAttributeCheck); // Get ID
            int.TryParse(PTAID, ref ptaID);
            p.insertSQL(queryProductToAttributeInsert, "Insert Product to Attribute Mapping " + itemID);
        }
    }
