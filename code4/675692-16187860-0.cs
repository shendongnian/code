    string str = "the stock overflow in very good website";
    string separator = "...";
    string joinedString = string.Join("", (str.Split()
                          .Select(r=> r + separator +
                                       (string.Join(separator, r.ToCharArray()))
                                       +separator)));
    Console.WriteLine(joinedString);
