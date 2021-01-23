        [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = true)]
    public class ConditionallyRequiredAttribute : RequiredAttribute {
        private MemberInfo _member;
        /// <summary>
        /// The name of the member that will return the state that indicates
        /// whether or not the validated member is required.
        /// </summary>
        public string ConditionMember { get; private set; }
        /// <summary>
        /// The condition value under which this validator treats
        /// the affected member as required.
        /// </summary>
        public object RequiredCondition { get; private set; }
        /// <summary>
        /// Comma-separated list of additional members to
        /// add to validation errors.  By default, the
        /// <see cref="ConditionMember"/> is added.
        /// </summary>
        public string ErrorMembers { get; set; }
        /// <summary>
        /// Conditionally require a value, only when the specified
        /// <paramref name="conditionMember"/> is <c>true</c>.
        /// </summary>
        /// <param name="conditionMember">
        /// The member that must be <c>true</c> to require a value.
        /// </param>
        public ConditionallyRequiredAttribute(string conditionMember)
            : this(conditionMember, true) { }
        /// <summary>
        /// Conditionally require a value, only when the specified
        /// <paramref name="conditionMember"/> has a value that
        /// exactly matches the <paramref name="requiredCondition"/>.
        /// </summary>
        /// <param name="conditionMember">
        /// The member that will be evaluated to require a value.
        /// </param>
        /// <param name="requiredCondition">
        /// The value the <paramref name="conditionMember"/> must
        /// hold to require a value.
        /// </param>
        public ConditionallyRequiredAttribute(string conditionMember, object requiredCondition) {
            this.ConditionMember = conditionMember;
            this.RequiredCondition = requiredCondition;
            this.ErrorMembers = this.ConditionMember;
        }
        /// <summary>
        /// Override the base validation to only perform validation when the required
        /// condition has been met.  In the case of validation failure, augment the
        /// validation result with the <see cref="ErrorMembers"/> as an additional
        /// member names, as needed.
        /// </summary>
        /// <param name="value">The value being validated.</param>
        /// <param name="validationContext">The validation context being used.</param>
        /// <returns>
        /// <see cref="ValidationResult.Success"/> if not currently required or if satisfied,
        /// or a <see cref="ValidationResult"/> in the case of failure.
        /// </returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
            if (this.DiscoverMember(validationContext.ObjectType)) {
                object state = this.InvokeMember(validationContext.ObjectInstance);
                // We are only required if the current state
                // matches the specified condition.
                if (Object.Equals(state, this.RequiredCondition)) {
                    ValidationResult result = base.IsValid(value, validationContext);
                    if (result != ValidationResult.Success && this.ErrorMembers != null && this.ErrorMembers.Any()) {
                        result = new ValidationResult(result.ErrorMessage,
                            result.MemberNames.Union(this.ErrorMembers.Split(',').Select(s => s.Trim())));
                    }
                    return result;
                }
                return ValidationResult.Success;
            }
            throw new InvalidOperationException(
                "ConditionallyRequiredAttribute could not discover member: " + this.ConditionMember);
        }
        /// <summary>
        /// Discover the member that we will evaluate for checking our condition.
        /// </summary>
        /// <param name="objectType"></param>
        /// <returns></returns>
        private bool DiscoverMember(Type objectType) {
            if (this._member == null) {
                this._member = (from member in objectType.GetMember(this.ConditionMember).Cast<MemberInfo>()
                                where IsSupportedProperty(member) || IsSupportedMethod(member)
                                select member).SingleOrDefault();
            }
            // If we didn't find 1 exact match, indicate that we could not discover the member
            return this._member != null;
        }
        /// <summary>
        /// Determine if a <paramref name="member"/> is a
        /// method that accepts no parameters.
        /// </summary>
        /// <param name="member">The member to check.</param>
        /// <returns>
        /// <c>true</c> if the member is a parameterless method.
        /// Otherwise, <c>false</c>.
        /// </returns>
        private bool IsSupportedMethod(MemberInfo member) {
            if (member.MemberType != MemberTypes.Method) {
                return false;
            }
            MethodInfo method = (MethodInfo)member;
            return method.GetParameters().Length == 0
                && method.GetGenericArguments().Length == 0
                && method.ReturnType != typeof(void);
        }
        /// <summary>
        /// Determine if a <paramref name="member"/> is a
        /// property that has no indexer.
        /// </summary>
        /// <param name="member">The member to check.</param>
        /// <returns>
        /// <c>true</c> if the member is a non-indexed property.
        /// Otherwise, <c>false</c>.
        /// </returns>
        private bool IsSupportedProperty(MemberInfo member) {
            if (member.MemberType != MemberTypes.Property) {
                return false;
            }
            PropertyInfo property = (PropertyInfo)member;
            return property.GetIndexParameters().Length == 0;
        }
        /// <summary>
        /// Invoke the member and return its value.
        /// </summary>
        /// <param name="objectInstance">The object to invoke against.</param>
        /// <returns>The member's return value.</returns>
        private object InvokeMember(object objectInstance) {
            if (this._member.MemberType == MemberTypes.Method) {
                MethodInfo method = (MethodInfo)this._member;
                return method.Invoke(objectInstance, null);
            }
            PropertyInfo property = (PropertyInfo)this._member;
            return property.GetValue(objectInstance, null);
        }
        #if !SILVERLIGHT
        /// <summary>
        /// The desktop framework has this property and it must be
        /// overridden when allowing multiple attributes, so that
        /// attribute instances can be disambiguated based on
        /// field values.
        /// </summary>
        public override object TypeId {
            get { return this; }
        }
        #endif
    }
