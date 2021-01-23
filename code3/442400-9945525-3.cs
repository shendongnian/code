    Item item;
    for (int i = 0; i < lines.Length; i++) {
        if (lines[i].StartsWith("Title ")) {
            item = new Item();
            result.Add(item);
            item.Title = lines[i].Substring(6);
        } else if (lines[i].StartsWith("Status: ")) {
            item.Status = lines[i].Substring(8);
        } else { // Description
            if (lines[i].Description != null) {
                lines[i].Description += "\r\n";
            }
            lines[i].Description += lines[i];
        }
    }
