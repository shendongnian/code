          routes.MapRoute(
              "EditFilter",
              "Edit/{YourFilter}/{id}",
              new { controller = "Contract", action = "Edit",YourFilter = UrlParameter.Optional,id = UrlParameter.Optional }
          );
