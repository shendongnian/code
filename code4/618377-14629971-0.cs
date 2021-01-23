    @using Nop.Core.Domain.Customers;
    @using Nop.Services.Customers;
    @using Nop.Core;
    @{
        bool customerHasRoleX = EngineContext.Current.Resolve<IWorkContext>().CurrentCustomer.IsInCustomerRole("Administrators");
        bool customerHasRoleY = EngineContext.Current.Resolve<IWorkContext>().CurrentCustomer.IsInCustomerRole("ForumModerators");
    }
    @if ((customerHasRoleX == true) | (customerHasRoleY == true)) {
    
    }
    else
    {
        Response.Redirect("~/login?ReturnUrl=%2fboards");
    }
