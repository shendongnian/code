        public ChildWindow()
            :base()
        {
            var appCloseCommandBinding =
                CommandBindings.Cast<CommandBinding>().SingleOrDefault(item => item.Command == ApplicationCommands.Close);
            if(appCloseCommandBinding != null)
                CommandBindings.Remove(appCloseCommandBinding);
            CommandBindings.Add(new CommandBinding(ApplicationCommands.Close, YourCommandLogic));
        }
