      foreach (UIElement item in (sender as ListBox).Items)
      {
        foreach (UIElement InnerItem in (item as StackPanel).Children)
        {
          if ((InnerItem is TextBlock) && (InnerItem as TextBlock).Name.Equals("title"))
          {
            MessageBox.Show((InnerItem as TextBlock).Text);
          }
        }
      }
    }
    }
