    DisplayModeProvider.Instance.Modes.Insert(0, new
            DefaultDisplayMode("Tablet")
            {
                ContextCondition = (ctx =>
                ctx.Request.UserAgent.IndexOf("iPad", StringComparison.OrdinalIgnoreCase) >= 0 ||
                ctx.Request.UserAgent.IndexOf("Android", StringComparison.OrdinalIgnoreCase) >= 0 && 
                ctx.Request.UserAgent.IndexOf("mobile", StringComparison.OrdinalIgnoreCase) < 1)
            });
            DisplayModeProvider.Instance.Modes.Insert(1, new DefaultDisplayMode("Mobile")
            {
                ContextCondition = (ctx =>
                    ctx.GetOverriddenBrowser().IsMobileDevice)
            });
