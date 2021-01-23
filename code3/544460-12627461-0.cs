    if (x > 5)
    {
        bool isValidDate = DateTime.TryParse(y, out z);
        if (!isValidDate || z > w)
        {
            // comment like: stop processing if the current date 
            // is after the reference date, or if there was a parsing error
            break;
        }
    }
