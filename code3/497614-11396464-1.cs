     var image = Image.FromFile(@"C:\Tools\test.jpg");
     var propertyItem = createPropertyItem();
     var text = "awe" + char.MinValue;//add \0 at the end of your string
     propertyItem = createPropertyItem();
     propertyItem.Id = 40091;
     propertyItem.Value = Encoding.Unicode.GetBytes(text);//change to Unicode
     propertyItem.Len = propertyItem.Value.Length;
     propertyItem.Type = 1;//it's not type 2 !
     image.SetPropertyItem(propertyItem);
     image.Save(@"C:\Tools\test2.jpg");
     
