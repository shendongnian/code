        /// <summary>
        /// AttachEntityToObjectContext attaches an EntityObject to an ObjectContext
        /// </summary>
        /// <param name="entityWithRelationships">An EntityObject that has relationships</param>
        /// <param name="newContext">The ObjectContext to attach the entity to</param>
        /// <returns>True if the entity has relationships (and therefore the method could succeed). Otherwise false.</returns>
        /// <remarks>Objects are retrieved using one ObjectContext, stored in ViewState and then
        /// an attempt to save them is then made. The save attempt does not save the object. This is because it is a different context which is saving the object.
        /// So the object needs to be detached from its old context, added to the new context and have its EntityState maintained so that it gets saved.</remarks>
        public static bool AttachEntityToObjectContext(this IEntityWithRelationships entityWithRelationships, ObjectContext newContext)
        {
            EntityObject entity = entityWithRelationships as EntityObject;
            if (entity == null)
            {
                return false;
            }
            if (entity.EntityState != EntityState.Detached)
            {
                ObjectContext oldContext = entity.GetContext();
                if (oldContext == null)
                {
                    return false;
                }
                if (oldContext != newContext)
                {
                    EntityState oldEntityState = entity.EntityState;
                    oldContext.Detach(entity);
                    newContext.Attach(entity);
                    newContext.ObjectStateManager.ChangeObjectState(entity, oldEntityState);
                }
            }
            return true;
        }
        /// <summary>
        /// GetContext gets the ObjectContext currently associated with an entity
        /// </summary>
        /// <param name="entity">An EntityObject</param>
        /// <returns>The ObjectContext which the entity is currently attached to</returns>
        private static ObjectContext GetContext(this IEntityWithRelationships entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            var relationshipManager = entity.RelationshipManager;
            var relatedEnd = relationshipManager.GetAllRelatedEnds().FirstOrDefault();
            if (relatedEnd == null)
            {
                // No relationships found
                return null;
            }
            var query = relatedEnd.CreateSourceQuery() as ObjectQuery;
            if (query == null)
            {
                // The Entity is Detached
                return null;
            }
            return query.Context;
        }
