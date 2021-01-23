            if (pluginContext.InputParameters.Contains("Target") &&
                pluginContext.InputParameters["Target"] is Entity)
            {
                // Obtain the target entity from the input parmameters.
                var entity = (Entity)pluginContext.InputParameters["Target"];
                // get current date/time
                var now = DateTime.Now;
                entity.Attributes.Add("new_mydatetimefield", now);
            }
