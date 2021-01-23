        try
        {
            NewReleasesCharts homeData = JsonConvert.DeserializeObject<NewReleasesCharts>(e.Result);
            // foreach loop to dispaly data
            foreach (ResultHome rc in homeData)
            {
                foreach (FeaturedCharts fc in rc.featuredCharts)
                {
                    // return name and image of chart
                }
            }
        }
