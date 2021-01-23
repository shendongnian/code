    routes.MapRoute(
        "Section", // Route name
        "{controller}/{ action }", // URL with parameters
        new { 
            controller = "Poll", 
            action = "Section"
     
        } // Parameter defaults
    );
    
    routes.MapRoute(
        "SectionMember", // Route name
        "{controller}/{ action }/{id}", // URL with parameters
        new { 
            controller = "Poll", 
            action = "SectionMember",
            id = UrlParameter.Optional
        } // Parameter defaults
    );
    
    routes.MapRoute(
        "SectionOrganization", // Route name
        "{controller}/{ action }/{organization}", // URL with parameters
        new { 
            controller = "Poll", 
            action = "SectionOrganization",
     organization= UrlParameter.Optional 
        } // Parameter defaults
    );
    
    routes.MapRoute(
        "SectionOrganizationMember", // Route name
        "{controller}/{ action }/{organization}/{id}", // URL with parameters
        new { 
            controller = "Poll", 
            action = "SectionOrganizationMember", 
            organization= UrlParameter.Optional ,
            id = UrlParameter.Optional 
        } // Parameter defaults
    );
    
    routes.MapRoute(
        "SectionMemberKey", // Route name
        "{controller}/{ action }/{id}/{key}", // URL with parameters
        new { 
            controller = "Poll", 
            action = "SectionMemberKey", 
            id = UrlParameter.Optional,
            key = UrlParameter.Optional
        } // Parameter defaults
    );
    
    routes.MapRoute(
        "SectionOrganizationMemberKey", // Route name
        "{controller}/{action }/{organization}/{id}/{key}", // URL with parameters
        new { 
            controller = "Poll", 
            action = "SectionOrganizationMemberKey", 
    organization= UrlParameter.Optional ,
            id = UrlParameter.Optional,
    key = UrlParameter.Optional
     
        } // Parameter defaults
    );
