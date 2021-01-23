    using System;
    using System.IO;
    using Microsoft.Office.Interop.Outlook;
    using Outlook = Microsoft.Office.Interop.Outlook;
    
    
    namespace OutlookCategory
    {
        class Program
        {
            static void Main(string[] args)
            {
                AddACategory();
            }
            private static void AddACategory()
            {
                string[] lines = File.ReadAllLines(@"C:\CategoryList.txt");
                var app = new Application(); 
                foreach (string line in lines)
                {
                    string[] LineArray = line.Split('|');                               
                    var color = LineArray[1];
    
                    Outlook.Categories categories = app.Session.Categories;
                    //Add categories
                    if (CategoryExists(LineArray[0], app) == false)
                    {
                        categories.Add(LineArray[0], color);
                    }
                }
            }
            private static bool CategoryExists(string categoryName, Application app)
            {
                try
                {
                    Outlook.Category category =
                        app.Session.Categories[categoryName];
                    if (category != null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch { return false; }
            }
        }
    }
