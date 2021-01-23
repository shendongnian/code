    public static class AssertionsExtensions
    {
        [NotNull]
        public static TSubject ShouldNotBeNull<TSubject>([CanBeNull] this TSubject source,
            [CanBeNull] string because = "", [CanBeNull] [ItemCanBeNull] params object[] reasonArgs)
        {
            source.Should().NotBeNull(because, reasonArgs);
            // ReSharper disable once AssignNullToNotNullAttribute
            return source;
        }
    }
