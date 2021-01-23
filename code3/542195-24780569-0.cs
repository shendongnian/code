      public class SimpleNameValueItem
        {
            public string Name { get; set; }
    
            public Guid Uid { get; set; }
    
            public int Id { get; set; }
    
            public string Value { get; set; }
    
        }
      var shapeItems = from x in AppModel.ShapeTypes select new SimpleNameValueItem { Name = x.ShapeName, Uid = x.UID };
