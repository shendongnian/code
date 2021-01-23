        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String MobilePhoneNo 
        {
            get
            {
                return _MobilePhoneNo;
            }
            set
            {
                OMobilePhoneNoChanging(value);
                ReportPropertyChanging("MobilePhoneNo");
                _MobilePhoneNo = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("MobilePhoneNo");
                OnMobilePhoneNoChanged();
            }
        }
        private global::System.String _MobilePhoneNo;
        partial void OnMobilePhoneNoChanging(global::System.String value);
        partial void OnMobilePhoneNoChanged();
