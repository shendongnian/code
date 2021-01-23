    foreach (String tmpPosition in imagePositions)
    {
        // add logic here to skip if imagePosition has already been selected 
        // or just don't include it in imagePositions is it has already been selected
        String[] parts = tmpPosition.Split(new char[] { '|' });
        image_position.Items.Add(new ListItem(parts[1], parts[0]));
    }
