        [Obsolete("Property Duration should be used instead.")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public long DurationTicks { get; set; }
    
        public TimeSpan Duration
        {
    #pragma warning disable 618
          get { return new TimeSpan(DurationTicks); }
          set { DurationTicks = value.Ticks; }
    #pragma warning restore 618
        }
