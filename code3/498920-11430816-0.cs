    int firstMonth = Int32.Parse(dt1.Month);
    int secondMonth = Int32.Parse(dt2.Month);
    int year = Int32.Parse(dt1.Year);
    // You could do some checking if the year is different or something.
    for(int month = firstMonth; month <= secondMonth; month++)
        // Add the date to the drop down list by using (month + year).ToString()
