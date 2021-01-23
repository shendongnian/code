    // Added String as the function type so you can return the matched "Integer" as a string, you could always do a Int32.TryParse(...)
    private String searchFile(String file, String searchText)
    {
        System.IO.StreamReader reader = new System.IO.StreamReader(file);
        String text = reader.ReadToEnd();
        int32 index = text.IndexOf(searchText);
        if (index >= 0) //We could find it at the very beginning
        {
            MessageBox.Show(searchText + " was found in the given file", "Finally!!");
            int32 start = index + searchText.Length;
            int32 end = Regex.Match(text, "[\n\r\t]", index).Index; // This will search for whitespace
            String value = text.Substring(start, end - start);
            // Now you can do something with your value, like...
            return value;
        }
        else
        {
            MessageBox.Show("Sorry, but " + searchText + " could not be found in the given file", "No Results");
            return "";
        }
    }
