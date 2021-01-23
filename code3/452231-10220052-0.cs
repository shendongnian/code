    private void dataPager_PageIndexChanged(object sender, System.EventArgs e)
    {
      
        if ((sender as DataPager).Visibility == System.Windows.Visibility.Visible)
        {
          if((sender as DataPager).GetVisualDescendants().Count != 0)
           {
               if ((sender as DataPager).PageIndex == (sender as DataPager).PageCount - 1)
               {
                (sender as DataPager).GetVisualDescendants().OfType<Button>().Where(b => b.Name == "NextPageButton").SingleOrDefault().IsEnabled = false;
               }
               else
                (sender as DataPager).GetVisualDescendants().OfType<Button>().Where(b => b.Name == "NextPageButton").SingleOrDefault().IsEnabled = true;
           }
       }
    }
