    int cursorRow = 0;
    int cursorPosition = 0;
    int maxRowLength = 5;
    List<Item> items = //fill with item list
    List<List<Item>> result = new List<List<Item>>();
    result.Add(new List<Item>());
    while (items.Count() > 0)
    (
        Item item = FindLongestItemAtPosition(cursorPosition);
        if (item != null)
        {
            result[cursorRow][cursorPosition] = item;
            items.Remove(item);
            cursorPosition += item.Length;
        }
        else //No items remain with this position
        {
            cursorPosition++;
        }
        if (cursorPosition == maxRowLength)
        {
            cursorPosition = 0;
            cursorRow++;
            result.Add(new List<Item>());
        }
    }
