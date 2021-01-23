    foreach (CultureInfo ci in CultureInfo.GetCultures(CultureTypes.AllCultures))
    {
         Console.Write("{0,-7}", ci.Name);
         Console.Write(" {0,-3}", ci.TwoLetterISOLanguageName);
         Console.Write(" {0,-3}", ci.ThreeLetterISOLanguageName);
         Console.Write(" {0,-3}", ci.ThreeLetterWindowsLanguageName);
         Console.Write(" {0,-40}", ci.DisplayName);
         Console.WriteLine(" {0,-40}", ci.EnglishName);
    }
