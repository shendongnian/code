    if (true)
    {
        if (!false)
        {
            //Some indented code;
            stringLiteral = string.format(
                        "This is a really long string literal" +
                        "I don't want it to have whitespace at " +
                        "the beginning of each line, so I have" +
                        "to break the indentation of my program" +
                        "I also have vars here" +
                        "{0}" +
                        "{1}" +
                        "{2}",
                      var1, var2, var3);
              // OR, with lineskips:
            stringLiteral = string.format(
                        "This is a really long string literal\r\n" +
                        "I don't want it to have whitespace at \r\n" +
                        "the beginning of each line, so I have\r\n" +
                        "to break the indentation of my program\r\n"
                        "I also have vars here\r\n" +
                        "{0}\r\n" +
                        "{1}\r\n" +
                        "{2}\r\n",
                      var1, var2, var3);
        }
    }
