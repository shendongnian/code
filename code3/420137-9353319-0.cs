    /// <summary>
        /// Maps MembershipUser entity to MyMembershipUser business object.
        /// </summary>
        /// <param name="entity">A MembershipUser entity.</param>
        /// <returns>A product business object.</returns>
        internal static MyMembershipUser Map(MembershipUser entity)
        {
            return new MyMembershipUser 
            {
                Id = entity.Id,
                Name= entity.Name,
            };
        }
