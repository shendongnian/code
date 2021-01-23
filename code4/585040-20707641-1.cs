     /// <summary>
    /// implement by divyang
    /// </summary>
    [Serializable]
    [IntroduceInterface(typeof(IPseudoImmutable),
        AncestorOverrideAction = InterfaceOverrideAction.Ignore, OverrideAction = InterfaceOverrideAction.Fail)]
    public class PseudoImmutableAttribute : InstanceLevelAspect, IPseudoImmutable
    {
        
        private volatile bool isFrozen;
        #region "IPseudoImmutable"
        
        [IntroduceMember]
        public bool IsFrozen
        {
            get
            {
                return this.isFrozen;
            }
        }
        [IntroduceMember(IsVirtual = true, OverrideAction = MemberOverrideAction.Fail)]
        public bool Freeze()
        {
            if (!this.isFrozen)
            {
                this.isFrozen = true;
            }
            return this.IsFrozen;
        }
        #endregion
        [OnLocationSetValueAdvice]
        [MulticastPointcut(Targets = MulticastTargets.Property | MulticastTargets.Field)]
        public void OnValueChange(LocationInterceptionArgs args)
        {
            if (!this.IsFrozen)
            {
                args.ProceedSetValue();
            }
        }
    }
    public class ImmutableException : Exception
    {
        /// <summary>
        /// The location name.
        /// </summary>
        private readonly string locationName;
        /// <summary>
        /// Initializes a new instance of the <see cref="ImmutableException"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public ImmutableException(string message)
            : base(message)
        {
        }
        public ImmutableException(string message, string locationName)
            : base(message)
        {
            this.locationName = locationName;
        }
        public string LocationName
        {
            get
            {
                return this.locationName;
            }
        }
    }
