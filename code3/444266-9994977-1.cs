        /// <summary>
        /// The deserialized.
        /// </summary>
        /// <param name="context">
        /// The streaming context.
        /// </param>
        [OnDeserialized]      
        private void Deserialized(StreamingContext context)
        {
           // reflection for backward compatibilty only
            if (this.ExtensionData == null)
            {
                return;
            }
            IList members = this.CheckForExtensionDataMembers();
            if (members == null)
            {
                return;
            }
 
            string value = this.GetExtensionDataMemberValue(members, "ItemSource");
            // do something with value
            value = this.GetExtensionDataMemberValue(members, "ErrorSource");
            // do something with value
           
        }
        /// <summary>
        /// The check for extension data members.
        /// </summary>
        /// <returns>
        /// Thel list of extension data memebers.
        /// </returns>
        private IList CheckForExtensionDataMembers()
        {
            PropertyInfo membersProperty = typeof(ExtensionDataObject).GetProperty(
                "Members", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            var members = (IList)membersProperty.GetValue(this.ExtensionData, null);
            if (members == null || members.Count <= 0)
            {
                return null;
            }
            return members;
        }
        /// <summary>
        /// The get extension data member value.
        /// </summary>
        /// <param name="members">
        /// The members.
        /// </param>
        /// <param name="dataMemberName">
        /// The data member name.
        /// </param>
        /// <returns>
        /// Returns extension data member value.
        /// </returns>
        private string GetExtensionDataMemberValue(IList members, string dataMemberName)
        {
            string innerValue = null;
            object member =
                members.Cast<object>().FirstOrDefault(
                    m =>
                    ((string)m.GetType().GetProperty("Name", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public).GetValue(m, null)).Equals(
                        dataMemberName, StringComparison.InvariantCultureIgnoreCase));
            if (member != null)
            {
                PropertyInfo valueProperty = member.GetType().GetProperty("Value", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                object value = valueProperty.GetValue(member, null);
                PropertyInfo innerValueProperty = value.GetType().GetProperty("Value", BindingFlags.Public | BindingFlags.Instance | BindingFlags.Public);
                object tmp = innerValueProperty.GetValue(value, null);
                var s = tmp as string;
                if (s != null)
                {
                    innerValue = s;
                }
            }
            return innerValue;
        }
