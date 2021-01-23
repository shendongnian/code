    namespace Your.Project.Interfaces
    {
        /// <summary>
        ///     Represents an entity used with Entity Framework Code First.
        /// </summary>
        public interface IEntity
        {
            /// <summary>
            ///     Gets or sets the identifier.
            /// </summary>
            /// <value>  
            ///     The identifier.
            /// </value>
            int Id { get; set; }
        }
    }
