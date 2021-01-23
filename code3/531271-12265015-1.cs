        /// <summary>
        /// A method to reherpinate colors or something lol
        /// </summary>
        /// <param name="initial">An initial value for the <see cref="Color"/>
        /// to apply the reherpenation algorithm on.</param>
        /// <param name="count">(optional)The average herp of the derp.</param>
        /// <returns>A reherpenated <see cref="Color"/></returns>
        /// <remarks>Implementations should avoid fooing the bar if <paramref name="count"/>
        /// is <see cref="double.NaN"/>.</remarks>
        public delegate Color HerpinateColor(Color initial, double count = double.NaN);
