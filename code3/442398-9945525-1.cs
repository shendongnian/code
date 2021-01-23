    Item item;
    for (int i = 0; i < lines.Length; i++) {
        if (line[i].StartsWith("Title ")) {
            item = new Item();
            result.Add(item);
            item.Title = line[i].Substring(6);
        } else if (line[i].StartsWith("Status: ")) {
            item.Status = line[i].Substring(8);
        } else { // Description
            if (line[i].Description != null) {
                line[i].Description += "\r\n";
            }
            line[i].Description += line[i];
        }
    }
