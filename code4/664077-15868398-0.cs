    public bool Search(int item)
    {
        bool isInArray = false;
        if (Items != null)
        {
            for (int i = 0; i < Items.Length; i++) // ERROR HERE
            {
                if (Items[i] == item)
                {
                    isInArray = true;
                    break;
                }
            }
        }
        return isInArray;
    }
