     internal ItemsControl.ItemInfo LeaseItemInfo(ItemsControl.ItemInfo info, bool ensureIndex = false)
        {
          if (info.Index < 0)
          {
            info = this.NewItemInfo(info.Item, (DependencyObject) null, -1);
            if (ensureIndex && info.Index < 0)
              info.Index = this.Items.IndexOf(info.Item);
          }
          return info;
        }
