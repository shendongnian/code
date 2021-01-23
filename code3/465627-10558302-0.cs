    routes.MapRoute(
        "Issues Root",
        "issues",
        new { controller = "RedMine", action = "ListIssues" }
    );
    routes.MapRoute(
        "Project Issues",
        "projects/{projectName}/issues",
        new { controller = "RedMine", action = "ListIssues" }
    );
