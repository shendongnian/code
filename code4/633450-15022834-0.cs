	var result = strings.OrderBy(x =>
                             {
                                 int y = int.MinValue;
                                 int.TryParse(x.Substring(2), out y);
                                 return y;
                             });
