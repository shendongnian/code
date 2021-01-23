var job = new EncodeJob
	{
		EncodingProfile = profile,
		RangeType = VideoRangeType.All,
		Title = 1,
		SourcePath = SourceFile,
		OutputPath = AppDomain.CurrentDomain.BaseDirectory + "Output.mp4",
		ChosenAudioTracks = new List<int> { 1 },
		Subtitles = new Subtitles
			{
				SourceSubtitles = new List<SourceSubtitle>(),
				SrtSubtitles = new List<SrtSubtitle>()
			}
	};
