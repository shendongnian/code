        // This is a property on a GalaSoft MVVMLIght ViewModel
        /// <summary>
        ///   ThemeInfo of the current active theme
        /// </summary>
        public String ActiveTheme
        {
            get
            {
                if (activeTheme == null)
                {
                    activeTheme = Properties.Settings.Default.Default_App_Theme;
                }
                return activeTheme;
            }
            set
            {
                if (activeTheme == value)
                {
                    return;
                }
                var oldValue = activeTheme;
                activeTheme = value;
                // Update bindings
                RaisePropertyChanged(ActiveThemePropertyName,    oldValue, value, true);
                if (value != null)
                {
                     
                    
                         if (this.SwitchThemeCommand.CanExecute(value))
                            this.SwitchThemeCommand.Execute(value); 
                }
            }
        }
