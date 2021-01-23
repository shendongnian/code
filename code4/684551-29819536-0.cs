        public static void UpdateTour(Tour tour, TourPlan tourPlan)
        {
            using (var context = new aisatourismEntities())
            {
                context.Tours.Attach(tour);
       
                context.Entity(tourPlan).Property(plan => plan.Title).IsModified = true;
                context.SaveChanges();
            }
        }
