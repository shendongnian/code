        public override void RuntimeInitialize(MethodBase method)
        {
            base.RuntimeInitialize();
            this._checker =PermissionsCheckerProvider.Current.GetChecker();
        }
