        if (tempNumbers.Count >= 24)
        {
            listBoxNumbers.Items.AddRange(tempNumbers.ToArray());
            tempNumbers.Clear();
        }
