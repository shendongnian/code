    if (DateTime.TryParseExact("Fri May 03 15:22:09 +0000 2013",
                                                  "ddd MMMM dd HH:mm:ss zzz yyyy",
                                                  CultureInfo.InvariantCulture,
                                                  DateTimeStyles.None,
                                                  out ArticleDate))
                {
                    //date is fine
                }
