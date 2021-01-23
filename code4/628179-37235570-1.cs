            public void HideCurtain()
        {
            int childCount = VisualTreeHelper.GetChildrenCount(mainGrid);
            for (int i = 0; i < childCount; i++)
            {
                CurtainUserControl guc = mainGrid.Children.ElementAt(i) as CurtainUserControl;
                if (guc != null)
                {
                    mainGrid.Children.RemoveAt(i);
                }
            }
         }
