        routes.MapRoute(
            "SectionOrganizationMemberKey", // Route name
            "{controller}/{section}/{organization}/{id}/{key}", // URL with parameters
            new { controller = "Poll", action = "SectionOrganizationMemberKey" } // Parameter defaults
        );
        routes.MapRoute(
            "SectionOrganizationMember", // Route name
            "{controller}/{section}/{organization}/{id}", // URL with parameters
            new { controller = "Poll", action = "SectionOrganizationMember" }, // Parameter defaults
            new { id = @"\d+" }
        );
        routes.MapRoute(
            "SectionMemberKey", // Route name
            "{controller}/{section}/{id}/{key}", // URL with parameters
            new { controller = "Poll", action = "SectionMemberKey" } // Parameter defaults
        );
        routes.MapRoute(
            "SectionMember", // Route name
            "{controller}/{section}/{id}", // URL with parameters
            new { controller = "Poll", action = "SectionMember" }, // Parameter defaults
            new { id = @"\d+" }
        );
        routes.MapRoute(
            "SectionOrganization", // Route name
            "{controller}/{section}/{organization}", // URL with parameters
            new { controller = "Poll", action = "SectionOrganization" }
        );
        routes.MapRoute(
            "Section", // Route name
            "{controller}/{section}", // URL with parameters
            new { controller = "Poll", action = "Section" } // Parameter defaults
            );
