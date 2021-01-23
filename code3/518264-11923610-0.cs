     class MyRootElement : RootElement {
          string ShortName;
          public MyRootElement (string caption, string shortName)
              : base (caption)
          {
              ShortName = shortName;
          }
          public override UITableViewCell GetCell (UITableView tv)
          {
               var cell = base.GetCell (tv);
               cell.TextLabel.Text = ShortName;
          }
     }
