    namespace so.consoleapp
    {
        using System;
        using System.Collections.Generic;
        using System.Xml.Linq;
    
        class Program
        {
            static void Main(string[] args)
            {
                var doc = XElement.Load("file.xml");
                var activityElements = doc.Elements("activity");
    
                ICollection<Activity> collectionOfActivities = new List<Activity>();
                foreach (var activityElement in activityElements)
                {
                    var storageObjectElement = activityElement.Element("storageObject");
    
                    string clientElement = null;
                    if (storageObjectElement.Element("Client") != null)
                    {
                        clientElement = storageObjectElement.Element("Client").Value;
                    }
    
                    var newStorageObject = new StorageObject
                    {
                        Client = clientElement,
                        Author = storageObjectElement.Element("Author").Value
                    };
    
                    var userElement = activityElement.Element("user");
                    var newUser = new User
                    {
                        Id = userElement.Attribute("id").Value,
                        Name = userElement.Attribute("name").Value,
                        MemberType = userElement.Attribute("memberType").Value
                    };
                 
                    collectionOfActivities.Add
                    (
                        new Activity
                        {
                            Date = activityElement.Attribute("date").Value,
                            Name = activityElement.Attribute("name").Value,
                            Host = activityElement.Attribute("host").Value,
                            User = newUser,
                            StorageObject = newStorageObject
                        }
                    );
                }
    
                Console.ReadLine();
            }
        }
    
        class Activity
        {
            public string Date
            {
                get;
                set;
            }
    
            public string Name
            {
                get;
                set;
            }
    
            public string Host
            {
                get;
                set;
            }
    
            public User User
            {
                get;
                set;
            }
    
            public StorageObject StorageObject
            {
                get;
                set;
            }
        }
    
        class User
        {
            public string Id
            {
                get;
                set;
            }
    
            public string Name
            {
                get;
                set;
            }
    
            public string MemberType
            {
                get;
                set;
            }
        }
    
        class StorageObject
        {
            public string Client
            {
                get;
                set;
            }
    
            public string Author
            {
                get;
                set;
            }
        }
    }
