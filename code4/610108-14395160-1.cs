        DateTime dateTime;
        if (DateTime.TryParse(KeyWord, out dateTime))
        {
            KeyWord = ((Month)dateTime.Month).ToString();
        }
