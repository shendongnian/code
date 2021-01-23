    class TenantProvider : ITenantProvider
    {   
        Tenant Tenant
        {
            get
            {
                Tenant tenant = HttpContent.Current.Items["Tenant"] as Tenant;
                if (tenant == null)
                {
                    string domain = GetDomain();
                    tenant = TenantRepository.GetTenantByDomain(domain);
                    HttpContext.Current.Items["Tenant"] = tenant;
                }
                return tenant;
            }
        }
    }
