    return db.Restaurants
          .Include(rest => rest.Meals)
          .Where(rest => rest.City.Name == city)
          .OrderBy(r => r.Order)
          .AsEnumerable() // <-- Materiazling the query before projection
          .Select(r => new RestaurantDayMealsView()
              {
              Id = r.Id,
              Name = r.Name,
              Meals = r.Meals.Where(meal => meal.Date == DateTime.Today).ToList(),
              IsPropagated = r.IsPropagated
              }).Where(r => r.Meals.Count > 0);
