    List<string> arrayValues = new List<string>();
    if (array != null && array.Element != null)
    {
        for (int i = 0; i < array.Element.length; ++i)
        {
            //bool found = false;
            if (array.Element[i] != null && array.Element[i].Object != null)
            {
                for (int o = 0; o < array.Element[i].Object.length; ++o)
                {
                    if (array.Element[i].Object[o] != null && !string.IsNullOrEmpty(array.Element[i].Object[o].Item))
                    {
                        arrayValues.Add(array.Element[i].Object[o].Item);
                        //if you want to drop out here, you put a boolean in the bottom loop and break and then break out of the bottom loop if true
                        //found = true;
                         //break;
                    }
                }
            }
            //if (found)
            //  break;
        }
    }
    if (arrayValues.Count > 0)
    {
        //do stuff with arrayValues
    }
