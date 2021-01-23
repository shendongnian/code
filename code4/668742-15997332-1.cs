    string input = "MyString MyString";
    var words = input.Split().GroupBy(s => s).ToDictionary(
                                                      g => g.Key, 
                                                      g => g.Count()
                                              );
