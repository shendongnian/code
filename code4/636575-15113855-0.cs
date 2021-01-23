    public override void RegisterArea(AreaRegistrationContext context)
    {
        context.MapRoute(
            "Administrativo_default",
            "Administrativo/{controller}/{action}/{id}",
            new { controller = "Home", action = "Index", id = UrlParameter.Optional },
            new[] { "Preparacao.Gerenciar.Web.Areas.Administrativo.Controllers" }
        );
    }
