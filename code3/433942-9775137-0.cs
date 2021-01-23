		///<summary>Represents a single video stream.</summary>
		public sealed class VideoStream : Media, IGeneralVideoAudioTextImageMenuCommon,
		IGeneralVideoAudioTextMenuCommon, IVideoAudioTextImageMenuCommon,
		IVideoTextImageCommon, /* ...ad nauseum. */
		{
			// What would you even name these variables?
			GeneralVideoAudioTextImageMenuCommon gvatimCommon;
			GeneralVideoAudioTextMenuCommon gvatmCommon;
			VideoAudioTextImageMenuCommon vatimCommon;
			VideoTextImageCommon vticCommon;
			public VideoStream(MediaInfo mi, int id) {
			gvatimCommon = new GeneralVideoAudioTextImageMenuCommon(mi, id);
			gvatmCommon = new GeneralVideoAudioTextMenuCommon(mi, id);
			vatimCommon = new VideoAudioTextImageMenuCommon(mi, id);
			vticCommon = new VideoTextImageCommon(mi, id);
			// --- and more. There are so far at least 10 groupings. 10!
			/* more code */
		}
