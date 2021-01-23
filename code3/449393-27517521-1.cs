        public static class PropertyChangedNotificationInterceptor
        {
            public static SynchronizationContext UIContext { get; set; }
            public static void Intercept(object target, Action onPropertyChangedAction, string propertyName)
            {
                if (UIContext != null)
                {
                    UIContext.Post(_ =>
                    {
                        onPropertyChangedAction();
                    }, null);
                }
                else
                {
                    onPropertyChangedAction();
                }
            }
        }
