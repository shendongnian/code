    // Get categories with all users in it
    // and get max count in a category across all categories
    List<List<Category>> categories = GetCategoriesWithUsers();
    int maxUsersInCategory = categories.Max(x => x.Count);
    using (StreamWriter writer = new StreamWriter("output.csv")
    {
        // Loop through each user per category
        for (int userCount = 0; userCount < maxUseresInCategory; userCount++)
        {
           string outputLine = string.Empty;
           // Loop through each category
           foreach(List<Category> category in categories)
           {
              // If category end isn't reached, add user
              if (category.Length > userCount)
              {
                  outputLine += category[userCount];
              }
              outputLine += ",";
           }
           outputLine = outputLine.Remove(outputLine.Length - 1);
           writer.WriteLine(outputLine);
        }
    }
       
