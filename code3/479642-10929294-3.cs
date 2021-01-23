    var result = indexList
            //"transform" your initial list of strings into a list of splitted strings (string[])
            .Select(list => list.Split(','))
            //in this new List of string[], select the first part in text, select and Convert the second part in DateTime. We now have a list of anonymous objects, composed of a string and a DateTime Property
            .Select(splittedList => new
                                        {
                                            text = splittedList[0],
                                            date = new DateTime(Convert.ToInt32(splittedList[1].Substring(4, 4)),
                                                                Convert.ToInt32(splittedList[1].Substring(2, 2)),
                                                                Convert.ToInt32(splittedList[1].Substring(0, 2)))
                                        })
            //group that new List by the text Property (one "entry" for each distinct "text")
            .GroupBy(textDateTimeList => textDateTimeList.text)
             //from this grouping, take the "key" (which is the "distinct text", and foreach "group", take the Max Date. We now have a new List of anonymous object, with a string Property and a DateTime Property
            .Select(group => new
                                 {
                                     stringField = group.Key,
                                     maxDateField = group.Max(dateField => dateField.date)
                                 });
