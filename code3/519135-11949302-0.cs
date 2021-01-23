	public sealed class SayPassword : NativeActivity
	{
		
		[RequiredArgument]
		public InArgument<ConnectionInfo> Connection { get; set; }
		[RequiredArgument]
		public InArgument<String> Password { get; set; }
		
		public InArgument<String> Language { get; set; }
		public InArgument<Int32?> Speaker { get; set; }
		#region Implementation
		private SaySpeech InnerSaySpeech { get; set; }
		private Variable<ConnectionInfo> TempConnectionInfo { get; set; }
		private Variable<String> TempUtterance { get; set; }
		private Variable<String[]> TempParameters { get; set; }
		private Variable<String> TempLanguage { get; set; }
		private Variable<Int32?> TempSpeaker { get; set; }
		#endregion
		public SayPassword()
		{
			TempConnectionInfo = new Variable<ConnectionInfo>();
			TempUtterance = new Variable<String>();
			TempParameters = new Variable<String[]>();
			TempLanguage = new Variable<String>();
			TempSpeaker = new Variable<Int32?>();
			InnerSaySpeech = new SaySpeech
			{
				Connection = new InArgument<ConnectionInfo>(TempConnectionInfo),
				Utterance = new InArgument<string>(TempUtterance),
				Parameters = new InArgument<string[]>(TempParameters),
				Language = new InArgument<string>(TempLanguage),
				Speaker = new InArgument<int?>(TempSpeaker)
			};
		}
		private String[] GetSentences(String password) {}
		private static string GetPlaceholderString(Int32 NumberOfPlaceholders) {}
		protected override void CacheMetadata(NativeActivityMetadata metadata)
		{
			base.CacheMetadata(metadata);
			metadata.AddImplementationVariable(TempConnectionInfo);
			metadata.AddImplementationVariable(TempUtterance);
			metadata.AddImplementationVariable(TempParameters);
			metadata.AddImplementationVariable(TempLanguage);
			metadata.AddImplementationVariable(TempSpeaker);
			metadata.AddImplementationChild(InnerSaySpeech);
		}
		protected override void Execute(NativeActivityContext context)
		{
			String[] SpeakablePassword = GetSentences(Password.Get(context));
			context.SetValue(TempConnectionInfo, Connection.Get(context));
			context.SetValue(TempUtterance, GetPlaceholderString(SpeakablePassword.Length));
			context.SetValue(TempParameters, SpeakablePassword);
			context.SetValue(TempLanguage, Language.Get(context));
			context.SetValue(TempSpeaker, Speaker.Get(context));
			context.ScheduleActivity(InnerSaySpeech);
		}
	}
