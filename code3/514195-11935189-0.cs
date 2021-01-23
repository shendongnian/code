    namespace AForge.Imaging.Filters {
        /// <summary>
        /// Provides utility methods to assist coding against the AForge.NET 
        /// Framework.
        /// </summary>
        public static class AForgeUtility {
            /// <summary>
            /// Makes a debug assertion that an image filter that implements 
            /// the <see cref="IFilterInformation"/> interface can 
            /// process an image with the specified <see cref="PixelFormat"/>.
            /// </summary>
            /// <param name="filterInfo">The filter under consideration.</param>
            /// <param name="format">The PixelFormat under consideration.</param>
            [Conditional("DEBUG")]
            public static void AssertCanApply(
                this IFilterInformation filterInfo, 
                PixelFormat format) {
                Debug.Assert(
                    filterInfo.FormatTranslations.ContainsKey(format),
                    string.Format("{0} cannot process an image " 
                        + "with the provided pixel format.  Provided "
                        + "format: {1}.  Accepted formats: {2}.",
                        filterInfo.GetType().Name,
                        format.ToString(),
                        string.Join( ", ", filterInfo.FormatTranslations.Keys)));
            }
        }
    }
