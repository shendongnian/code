    public enum SkeletonChooserMode
    {
        /// <summary>
        /// Use system default tracking
        /// </summary>
        DefaultSystemTracking,
        /// <summary>
        /// Track the player nearest to the sensor
        /// </summary>
        Closest1Player,
        /// <summary>
        /// Track the two players nearest to the sensor
        /// </summary>
        Closest2Player,
        /// <summary>
        /// Track one player based on id
        /// </summary>
        Sticky1Player,
        /// <summary>
        /// Track two players based on id
        /// </summary>
        Sticky2Player,
        /// <summary>
        /// Track one player based on most activity
        /// </summary>
        MostActive1Player,
        /// <summary>
        /// Track two players based on most activity
        /// </summary>
        MostActive2Player
    }
