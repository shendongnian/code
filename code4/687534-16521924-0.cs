    if (DateTime.TryParseExact("Fri May 03 15:22:09 +0000 2013",
                                                  "ddd MMMM dd HH:mm:ss +0000 yyyy",
                                                  CultureInfo.InvariantCulture,
                                                  DateTimeStyles.None,
                                                  out ArticleDate))
                {
                    //date is fine
                }
