    string password = string.Empty;
    for (int i = 0; i < test.Length - 8; i++)
         if (test.Substring(i, 8) == "password")
              for (int j = i + 8; test[j] != '\"'; j++)
                   if (test[j] != ' ')
                       password += test[j];
    Console.WriteLine(password); //somepass
