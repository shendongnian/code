        /// <summary>
        /// The TextTrimming property specifies the trimming behavior situation
        /// in case of clipping some textual content caused by overflowing the line's box.
        /// </summary>
        public TextTrimming TextTrimming
        {
            get { return (TextTrimming)GetValue(TextTrimmingProperty); }
            set { SetValue(TextTrimmingProperty, value); }
        }
