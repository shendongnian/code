     // Split the string into individual number strings
     List<String> items  = wrongOrderBase.Split(DELIMITER).ToList<String>();
     items.Sort(delegate(String strA, String strB)
                {
                    int intA = int.Parse(strA);
                    int intB = int.Parse(strB);
                    return intA.CompareTo(intB);
                });
      // Re-join back into one string
      String sortedListString = String.Join(DELIMITER.ToString(), items);
