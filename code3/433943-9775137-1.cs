	public class MultiStreamCommon : Media
	{
		public MultiStreamCommon(MediaInfo mediaInfo, StreamKind kind, int id)
			: base(mediaInfo, id) {
				this.kind = kind;
		}
		#region AllStreamsCommon
		string _format;
		///<summary>The format or container of this file or stream.</summary>
		///<example>Windows Media, JPEG, MPEG-4.</example>
		public string format { /* implementation */ };
		string _title;
		///<summary>The title of the movie, track, song, etc..</summary>
		public string title { /* implementation */ };
		/* more accessors */
		#endregion
		#region VideoAudioTextCommon
		/* Methods appropriate to this region. */
		#endregion
		// More regions, one for each grouping.
	}
