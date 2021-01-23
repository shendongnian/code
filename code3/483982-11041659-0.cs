    protected string NullHandler()(object gridViewObject)
       {
            if (object.ReferenceEquals(gridViewObject, DBNull.Value))
          {
                return "Empty";
           }
            else
           {
                return gridViewObject.ToString();
          }
        }
