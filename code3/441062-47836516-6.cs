        public static void ShowProperty(this PropertyGrid pg, string property, bool show)
        {
            for (int i = 0; i < pg.Properties.Count; ++i)
            {
                PropertyItem prop = pg.Properties[i] as PropertyItem;
                if (prop.PropertyName == property)
                {
                    prop.Visibility = show ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed;
                    break;
                }
            }
        }
