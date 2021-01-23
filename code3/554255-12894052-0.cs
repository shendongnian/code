                 select new {
                     Order = order,
                     Item = orderItem,
                     Product = product,
                     // I'd like to get these child items as IEnumerables or similar
                     ItemQuantities = orderItemQuantities.ToList(),
                     ActivityQuantities = activityQuantities.ToList()
                 };
