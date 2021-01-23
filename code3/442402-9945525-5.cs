    Item item;
    for (int i = 0; i < lines.Length; i++) {
        string line = lines[i];
        if (line.StartsWith("Title ")) {
            item = new Item();
            result.Add(item);
            item.Title = line.Substring(6);
        } else if (line.StartsWith("Status: ")) {
            item.Status = line.Substring(8);
        } else { // Description
            if (item.Description != null) {
                item.Description += "\r\n";
            }
            item.Description += line;
        }
    }
