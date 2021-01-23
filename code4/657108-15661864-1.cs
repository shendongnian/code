    get
    {
        double lat;
        if (double.TryParse(lat1.Text, out lat))
            return lat;
        else
        {
            // This line is reached if lat1.Text is not a valid double.
            // You decide what's best to do here
            return -1;
        }
    }
