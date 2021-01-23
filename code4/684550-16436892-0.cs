    public static int UpdateTour(Tour tour)
    {
       using (var context = new aisatourismEntities())
         {
            Tour tUpd = context.Tour.FirstOrDefault(t => t.Id == tour.Id);
              if (tUpd != null)
                {
                    tUpd.Title = tour.Title;
                    tUpd.TourPlan.Id= tour.TourPlan.Id;
                    tUpd.TourPlan.TourId= tour.TourPlan.TourId;
                    tUpd.TourPlan.Title = tour.TourPlan.Title;
                }
              return context.SaveChanges();
         }
     }
