    busConfigurationService.GetTenantsOverview()
                           .TenantsOverview
                           .Cast<TenantOverview>()
                           .Select(t => new { t.TenantId, t.Tenantnumber })
                           .OrderByDescending(t => t.Tenantnumber == "Any")
                           .ThenBy(t => t.Tenantnumber)
                           .ToList()
