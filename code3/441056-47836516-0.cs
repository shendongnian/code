        /// <summary>
        /// Show (or hide) a property within the property grid.
        /// Note: if you want to initially hide the property, it may be
        /// easiest to set the Browable attribute of the property to false.
        /// </summary>
        /// <param name="pg">The PropertyGrid on which to operate</param>
        /// <param name="property">The name of the property to show or hide</param>
        /// <param name="show">Set to true to show and false to hide</param>
        public static void ShowProperty(this PropertyGrid pg, string property, bool show)
        {
            int foundAt = -1;
            for (int i=0; i < pg.PropertyDefinitions.Count; ++i)
            {
                var prop = pg.PropertyDefinitions[i];
                if (prop.Name == property)
                {
                    foundAt = i;
                    break;
                }
            }
            if (foundAt == -1)
            {
                if (show)
                {
                    pg.PropertyDefinitions.Add(
                        new Xceed.Wpf.Toolkit.PropertyGrid.PropertyDefinition()
                        {
                            Name = "Repeat",
                        }
                    );
                }
            }
            else
            {
                if (!show)
                {
                    pg.PropertyDefinitions.RemoveAt(foundAt);
                }
            }
        }
