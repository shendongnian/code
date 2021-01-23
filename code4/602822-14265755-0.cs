        public Boolean? AllFeatureTypesChecked
        {
            get { return (Boolean?) GetValue(AllFeatureTypesCheckedProperty); }
            set { SetValue(AllFeatureTypesCheckedProperty, value); }
        }
        #region Using a DependencyProperty as the backing store for AllFeatureTypesCheck.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AllFeatureTypesCheckedProperty =
            DependencyProperty.Register("AllFeatureTypesCheck", typeof(Boolean?), typeof(ReportSources),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnAllFeatureTypesCheckedChanged));
        #endregion
