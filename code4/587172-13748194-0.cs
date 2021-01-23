    // Construct a tab-separated string with your variables:
    StringBuilder str = new StringBuilder();
    str.Append(i.ToString());
    str.Append("\t");
    str.Append(lineStart.ToString());
    str.Append("\t");
    str.Append(letters.ToString());
    ...
    // Push the string into your list:
    myList.Add(str.ToString());
    ...
    // Finally, you can write the contents of your list into a text file:
    System.IO.File.WriteAllLines("output.txt", myList.ToArray());
