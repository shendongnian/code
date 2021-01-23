      view.Resources.Add(typeof(GridViewColumnHeader), 
        new Style(typeof(GridViewColumnHeader)) 
        { 
          Setters = 
          {
            new Setter(GridViewColumnHeader.VisibilityProperty, Visibility.Collapsed)
          } 
        }
      );
