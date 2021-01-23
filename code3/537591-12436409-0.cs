     var names = ReferenceKey.GetNames(typeof(ReferenceKey));
     var values = ReferenceKey.GetValues(typeof(ReferenceKey)).Cast<int>().ToArray();
     var dict = new Dictionary<int, string>();
     for (int i = 0; i < names.Length; i++)
     {
         string name = names[i];
         int numChars = name.Length;
         for (int c = 1; c < numChars; c++)
         {
             if (char.IsUpper(name[c]))
             {
                 name = name.Insert(c, " ");
                 numChars++;
                 c++;
             }
         }
         dict[values[i]] = name;
     }
