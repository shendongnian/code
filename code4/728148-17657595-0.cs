        /// <summary>
        /// Handles GET requests that attempt to retrieve an individual entity by key from the entity set.
        /// </summary>
        /// <param name="key">The entity key of the entity to retrieve.</param>
        /// <returns>The response message to send back to the client.</returns>
        public virtual HttpResponseMessage Get([FromODataUri] TKey key)
        {
            TEntity entity = GetEntityByKey(key);
            return EntitySetControllerHelpers.GetByKeyResponse(Request, entity);
        }
