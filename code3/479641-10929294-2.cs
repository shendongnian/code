    var result = indexList
            .Select(list => list.Split(','))
            .Select(splittedList => new
                                        {
                                            text = splittedList[0],
                                            date = new DateTime(Convert.ToInt32(splittedList[1].Substring(4, 4)),
                                                                Convert.ToInt32(splittedList[1].Substring(2, 2)),
                                                                Convert.ToInt32(splittedList[1].Substring(0, 2)))
                                        })
            .GroupBy(textDateTimeList => textDateTimeList.text)
            .Select(group => new
                                 {
                                     stringField = group.Key,
                                     maxDateField = group.Max(dateField => dateField.date)
                                 });
