        private void CreateEvent(ClientPipelineArgs args)
        {
            var org_lang = Language.Current;
            Language lang = Language.Parse("en-gb");
            Language.Current = lang;
            Database db = Configuration.Factory.GetDatabase(args.Parameters["database"]);
            Item parent = db.GetItem(args.Parameters["id"], lang);
            try {
                // Create command context
                CommandContext command_context = new CommandContext(parent);
                // Get command
                Command command = CommandManager.GetCommand("fairsite:createcampaign");
                // Execute command
                command.Execute(command_context);
            } finally {
                Language.Current = org_lang;
            }
        }
