    private List<Spot> FilterSpots(List<Spot> spots, SearchCriteriaModel criteria)
        {
            if (criteria.PhotographyTypeIds != null || criteria.SeasonIds != null)
            {
                List<Spot> filteredSpots = new List<Spot>();
                if (criteria.PhotographyTypeIds != null)
                {
                    foreach (int id in criteria.PhotographyTypeIds)
                    {
                        var matchingSpots = spots.Where(x => x.PhotographyTypes.Any(p => p.ID == id));
                        filteredSpots.AddRange(matchingSpots.ToList());
                    }
                }
                if (criteria.SeasonIds != null)
                {
                    foreach (int id in criteria.SeasonIds)
                    {
                        if (filteredSpots.Count() > 0)
                        {
                            filteredSpots = filteredSpots.Where(x => x.Seasons.Any(p => p.ID == id)).ToList();
                        }
                        else
                        {
                            var matchingSpots = spots.Where(x => x.Seasons.Any(p => p.ID == id));
                            filteredSpots.AddRange(matchingSpots.ToList());
                        }
                    }
                }
                return filteredSpots;
            }
            else
            {
                return spots;
            }
        }
