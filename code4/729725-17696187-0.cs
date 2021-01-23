            private void SearchElement(DependencyObject targeted_control)
            {
                var count = VisualTreeHelper.GetChildrenCount(targeted_control);
                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        var child = VisualTreeHelper.GetChild(targeted_control, i);
                        if (child is CheckBox) // Only search for ChecBoxes
                        {
                            CheckBox targeted_element = (CheckBox)child;
                            // check/uncheck
                        }
                        else
                        {
                            SearchElement(child);
                        }
                    }
                }
                else
                {
                    return;
                }
            }
