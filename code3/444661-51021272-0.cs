        void SetTooltipForNonFittingItems(ListView listView)
        {
            var tooltip = new ToolTip();
            listView.MouseMove += (_1, e) =>
            {
                ListViewItem item = listView.GetItemAt(e.X, e.Y);
                if (item != null)
                {
                    using (Graphics graphics = listView.CreateGraphics())
                    {
                        var itemTextWidth = graphics.MeasureString(item.Text, item.Font).Width;
                        if (itemTextWidth > listView.Width)
                        {
                            if (!item.Equals(tooltip.Tag))
                            {
                                tooltip.Active = true;
                                tooltip.Tag = item;
                                // as written, the tooltip covers the item
                                // if you prefer to show it at the location of the cursor,
                                // use listView.PointToClient(Cursor.Position)
                                tooltip.Show(item.Text, listView, item.Position);
                            }
                        }
                        else
                        {
                            tooltip.Tag = null;
                            tooltip.Active = false;
                        }
                    }
                }
                else
                {
                    tooltip.Tag = null;
                    tooltip.Active = false;
                }
            };
        }
