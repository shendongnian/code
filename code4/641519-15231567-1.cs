     using (var image = new Bitmap(@"C:\Desert.jpg"))
                {
                    string filePath = @"C:\Desertcopy.jpg";
                    var data = Encoding.UTF8.GetBytes("my comment");
                    var propItem = image.PropertyItems.FirstOrDefault();
                    propItem.Type = 2;
                    propItem.Id = 0x010E; // <-- Image Description
                    propItem.Len = data.Length;
                    propItem.Value = data;
                    image.SetPropertyItem(propItem);
                    image.Save(filePath);
                }
