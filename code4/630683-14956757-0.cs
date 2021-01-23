    class DeleteCommandHandler
    {
        DW_MargoEntities context;
        public DeleteCommandHandler(DW_MargoEntities context)
        {
            this.context = context;
        }
        public bool Apply(DeleteCOmmand command)
        {
            if (not valid) {return false;}
            var item = context.LoadEntityById<EntityTypeHere>(command.SelectedItem) // Query the item
            context.Delete(item);
            return true;
        }
    }
