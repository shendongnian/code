    public class DisplayModeConfig
    {
        public static void RegisterDisplayModes(DisplayModeProvider provider)
        {
            // INFO: Allows to name views/partials/masters like viewname.iphone.cshtml, and MVC will choose this automatically
            
            // INFO: Lets remove the default "Mobile" mode, since it's pretty useless
            var mobileDefault = DisplayModeProvider.Instance.Modes.First(m => m.DisplayModeId == "Mobile");
            if (mobileDefault != null)
            {
                DisplayModeProvider.Instance.Modes.Remove(mobileDefault);
            }
            // INFO: Now add one that actually works
            provider.Modes.Insert(0,
                new DefaultDisplayMode("Mobile")
                {
                    ContextCondition = (context => (!string.IsNullOrEmpty(context.GetOverriddenUserAgent()) && Regex.IsMatch(context.GetOverriddenUserAgent(), @"mobile|android|kindle|silk|midp", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant)))
                });
            
            // INFO: Order from least to most important (since we insert at position 0)
            provider.Modes.Insert(1,
                new DefaultDisplayMode("Win8")
                {
                    ContextCondition = (context => (!string.IsNullOrEmpty(context.GetOverriddenUserAgent()) && context.GetOverriddenUserAgent().IndexOf("Windows NT 6.2", StringComparison.OrdinalIgnoreCase) >= 0))
                });
        }
    }
