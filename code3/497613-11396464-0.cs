     var image = Image.FromFile(@"C:\Tools\test.jpg");
     var propertyItem = createPropertyItem();
     propertyItem.Id = 40091;
     propertyItem.Len = "SomeText".Length;
     propertyItem.Type = 2;
     propertyItem.Value = Encoding.UTF8.GetBytes("SomeText");
     image.SetPropertyItem(propertyItem);
     image.Save(@"C:\Tools\test2.jpg");
     var newImage = Image.FromFile(@"C:\Tools\test2.jpg");
     var newPropertyItem = newImage.GetPropertyItem(40091);
     var chars = new char[newPropertyItem.Len-1];
     var encoding = new UTF8Encoding();
     encoding.GetDecoder().GetChars(newPropertyItem.Value, 0,newPropertyItem.Len-1, chars, 0);
     var newPropertyItemValue = new string(chars);//got "SomeText"
