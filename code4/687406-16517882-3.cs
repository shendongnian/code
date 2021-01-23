    protected virtual bool OnAttempt_AddItem(object args)
    {
        // TODO: handle unboxing exceptions, size of the array etc
        //
        try
        {
            object[] arr = (object[])args;
            switch (arr[0].ToString().ToLower())
            {
                // TODO: add other types (Radio etc)
                case "television":
                    var tv = new Television();
                    tv.ItemType = (string)arr[0];
                    tv.ItemName = (string)arr[1];
                    tv.ItemAmount = (arr.Length == 2) ? (int)arr[2] : 1;
                    tv.ItemACanHave = (arr.Length == 3) ? (int)arr[3] : 1;
                    tv.ItemClear = (bool)arr[4];
                    tv.ItemEffect = (string)arr[5];
                    tv.ItemModifier = (float)arr[6];
                    tv.ItemWeight = (int)arr[7];
                    // enforce ability to have atleast 1 item of each type
                    tv.ItemACanHave = Math.Max(1, tv.ItemACanHave);
                    InventoryItems.Add(tv);
                    break;
                default:
                    var genericItem = new InventoryItem();
                    genericItem.ItemType = (string)arr[0];
                    genericItem.ItemName = (string)arr[1];
                    genericItem.ItemAmount = (arr.Length == 2) ? (int)arr[2] : 1;
                    genericItem.ItemACanHave = (arr.Length == 3) ? (int)arr[3] : 1;
                    genericItem.ItemClear = (bool)arr[4];
                    genericItem.ItemEffect = (string)arr[5];
                    genericItem.ItemModifier = (float)arr[6];
                    genericItem.ItemWeight = (int)arr[7];
                    // enforce ability to have atleast 1 item of each type
                    genericItem.ItemACanHave = Math.Max(1, genericItem.ItemACanHave);
                    InventoryItems.Add(genericItem);
                    break;
                //handle other cases
            }
            return true;
        }
        catch (Exception ex)
        {
            // log the error
            return false;
        }
    }
