    public static class RegistrationBuilderExtensions
    {
        public static IRegistrationBuilder<TLimit, TActivatorData, TRegistrationStyle> InstancePerMatchingOrRootLifetimeScope<TLimit, TActivatorData, TRegistrationStyle>(this IRegistrationBuilder<TLimit, TActivatorData, TRegistrationStyle> builder, params object[] lifetimeScopeTag)
        {
            if (lifetimeScopeTag == null) throw new ArgumentNullException("lifetimeScopeTag");
            builder.RegistrationData.Sharing = InstanceSharing.Shared;
            builder.RegistrationData.Lifetime = new MatchingScopeOrRootLifetime(lifetimeScopeTag);
            return builder;
        }
    }
    public class MatchingScopeOrRootLifetime: IComponentLifetime
    {
        readonly object[] _tagsToMatch;
        public MatchingScopeOrRootLifetime(params object[] lifetimeScopeTagsToMatch)
        {
            if (lifetimeScopeTagsToMatch == null) throw new ArgumentNullException("lifetimeScopeTagsToMatch");
            _tagsToMatch = lifetimeScopeTagsToMatch;
        }
        public ISharingLifetimeScope FindScope(ISharingLifetimeScope mostNestedVisibleScope)
        {
            if (mostNestedVisibleScope == null) throw new ArgumentNullException("mostNestedVisibleScope");
            var next = mostNestedVisibleScope;
            while (next != null)
            {
                if (_tagsToMatch.Contains(next.Tag))
                    return next;
                next = next.ParentLifetimeScope;
            }
            return mostNestedVisibleScope.RootLifetimeScope;
        }
    }
