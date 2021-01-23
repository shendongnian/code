    [JsonObject(IsReference = true)]
    public class DuplicateEntityException : IActionResult
    {        
        public DuplicateEntityException(object duplicateEntity, object entityId)
        {
            this.EntityType = duplicateEntity.GetType().Name;
            this.EntityId = entityId;
        }
        /// <summary>
        ///     Id of the duplicate (new) entity
        /// </summary>
        public object EntityId { get; set; }
        /// <summary>
        ///     Type of the duplicate (new) entity
        /// </summary>
        public string EntityType { get; set; }
        public Task ExecuteResultAsync(ActionContext context)
        {
            var message = new StringContent($"{this.EntityType ?? "Entity"} with id {this.EntityId ?? "(no id)"} already exist in the database");
            var response = new HttpResponseMessage(HttpStatusCode.Ambiguous) { Content = message };
            return Task.FromResult(response);
        }
        #endregion
    }
