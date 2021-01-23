        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Property '" + nameof(Duration) + "' should be used instead.")]        
        public long DurationTicks { get; set; }
    
        [NotMapped]
        public TimeSpan Duration
        {
    #pragma warning disable 618
          get { return new TimeSpan(DurationTicks); }
          set { DurationTicks = value.Ticks; }
    #pragma warning restore 618
        }
