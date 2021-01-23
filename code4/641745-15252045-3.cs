        public virtual IMvxViewModel Load(Intent intent, IMvxSavedState savedState, Type viewModelTypeHint)
        {
            if (intent == null)
            {
                MvxTrace.Trace(MvxTraceLevel.Error, "Null Intent seen when creating ViewModel");
                return null;
            }
            if (intent.Action == Intent.ActionMain)
            {
                MvxTrace.Trace("Creating ViewModel for ActionMain");
                return Activator.CreateInstance(viewModelTypeHint) as IMvxViewModel;
            }
            if (intent.Extras == null)
            {
                MvxTrace.Trace(MvxTraceLevel.Error, "Null Extras seen on Intent when creating ViewModel - this should not happen - have you tried to navigate to an MvvmCross View directly?");
                return null;
            }
            IMvxViewModel mvxViewModel;
            if (TryGetEmbeddedViewModel(intent, out mvxViewModel))
            {
                MvxTrace.Trace("Embedded ViewModel used");
                return mvxViewModel;
            }
            MvxTrace.Trace("Loading new ViewModel from Intent with Extras");
            return CreateViewModelFromIntent(intent, savedState);
        }
