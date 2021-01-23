            Runspace runspace = RunspaceFactory.CreateRunspace();
            runspace.Open();
            Pipeline pipeline = runspace.CreatePipeline();
            Command dir = new Command("dir");
            pipeline.Commands.Add(dir);
            Command select = new Command("select");
            select.Parameters.Add("first", 3);
            pipeline.Commands.Add(select);
