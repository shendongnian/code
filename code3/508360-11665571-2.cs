        [System.Security.SecuritySafeCritical]
        public Boolean HasFlag(Enum flag) { 
            if (flag == null)
                throw new ArgumentNullException("flag"); 
            Contract.EndContractBlock(); 
            if (!this.GetType().IsEquivalentTo(flag.GetType())) { 
                throw new ArgumentException(Environment.GetResourceString("Argument_EnumTypeDoesNotMatch", flag.GetType(), this.GetType()));
            }
            return InternalHasFlag(flag); 
        }
        [System.Security.SecurityCritical]  // auto-generated 
        [ResourceExposure(ResourceScope.None)]
        [MethodImplAttribute(MethodImplOptions.InternalCall)] 
        private extern bool InternalHasFlag(Enum flags);
