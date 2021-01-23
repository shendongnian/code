    var products = db.GetTable<Product>();
    var projects = db.GetTable<Project>();
    var projectUpdates = db.GetTable<ProjectUpdate>();
    var latestProjectUpdatesForUser = projectUpdates
        .Where(x => x.CreatedBy == paramUser)
        .GroupBy(x => x.ProductId)
        .Select(g => g.OrderByDescending(x => x.LastUpdate).First());
    var list = products
        .Join(
            projects,
            product => product.ProjectId,
            project => project.Id,
            (product, project) => new
                {
                    Product = product,
                    Project = project,
                    Update = latestProjectUpdatesForUser.FirstOrDefault(u => u.ProductId == product.Id)
                }
        )
        .OrderByDescending(x => x.Update != null ? (DateTime?)x.Update.LastUpdate : null)
        .ThenBy(x => x.Project.Id)
        .ThenBy(x => x.Product.Id)
        .Select(x => new ProjectProduct { Project = x.Project, Product = x.Product});
