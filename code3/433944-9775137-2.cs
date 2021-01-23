	public sealed class VideoStream : Media
	{
		readonly MultiStreamCommon streamCommon;
 
		///<summary>VideoStream constructor</summary>
		///<param name="mediaInfo">A MediaInfo object.</param>
		///<param name="id">The ID for this audio stream.</param>
		public VideoStream(MediaInfo mediaInfo, int id) : base(mediaInfo, id) {
			this.kind = StreamKind.Video;
			streamCommon = new MultiStreamCommon(mediaInfo, kind, id);
		}
		public string format { get { return streamCommon.format; } }
		public string title { get { return streamCommon.title; } }
		public string uniqueId { get { return streamCommon.uniqueId; } }
		/* ...One line for every media function relevant to this stream type */
	}
