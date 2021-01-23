	protected override void WndProc(ref Message m)
	{
		if (m.Msg == WM_NCMOUSEMOVE)
		{
			//Mouse over on Minimize button
			if ((int)m.WParam == 0x8)
			{
				Speak("Minimize button");
			}
		}
		...
	}
	private SpeechSynthesizer _reader;
	void Speak(string toSpeak)
	{
		if (_reader == null)
		{
			_reader = new SpeechSynthesizer();
		}
		
		_reader.SpeakAsync(toSpeak);
	}
