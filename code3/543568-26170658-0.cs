        protected void chartarea1_CustomizeLegend(object sender, System.Web.UI.DataVisualization.Charting.CustomizeLegendEventArgs e)
        {
            int customItems = ((Chart)sender).Legends[0].CustomItems.Count();
            if (customItems>0)
            {
                int numberOfAutoItems = e.LegendItems.Count()-customItems;
                for (int i = 0; i < numberOfAutoItems; i++)
                {
                    e.LegendItems.RemoveAt(0);
                }
            }
            
        }
