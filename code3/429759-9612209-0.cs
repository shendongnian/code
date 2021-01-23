    // Restore the graph
    product.Activities.Add(activity1);
    product.Activities.Add(activity2);
    context.Products.Attach(product);
    
    // Delete the relationship
    product.Activities.Remove(activity1);
    context.SaveChanges();
