        HousePart housePart = new HousePart();
        housePart.Content = content;
        if (!string.IsNullOrEmpty(contentHouseOne[i]))
            housePart.ContentHouseOne = contentHouseOne[i];
        else
            housePart.ContentHouseOne = string.Empty;
        housePart.NewPosition = newPosition;
        listHouseParts.Add(housePart);
