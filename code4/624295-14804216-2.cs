    subscriptionTariff.SubscriptionServices.ToList().ForEach(ss =>
        {
            // get the instance of the correct subscriptionTariff using the
            // id (IdOfSubscriptionServices)
            var u = userTariff.SubscriptionServices.FirstOrDefault(e => e.IdOfSubscriptionServices == ss.IdOfSubscriptionServices);
    
            if (u != null)
            {
                // update each property
                u.Prop1 = ss.Prop1;
                u.Prop2 = ss.Prop2;
            }
        });
