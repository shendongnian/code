    ObjectContext IObjectContextAdapter.ObjectContext
            {
                get
                {
                    InternalContext.ForceOSpaceLoadingForKnownEntityTypes();
                    return InternalContext.ObjectContext;
                }
            }
