    public string[] utterance = new string[4];
	Dictionary<string, List<string>> wording = new Dictionary<string, List<string>>();
	public void splitit()
	{          
	 utterance[0] = "Fish attacked Nemo's parents";
	 utterance[1] = "Only one fish egg left after fish attacked Nemo's parents and that was Nemo.";
	 utterance[2] = "Nemo grow up and went to school.";
	 utterance[3] = "Nemo got bored during the lecture and went to ocean with his friends.";
		for (int x=0; x < 4; x++)
		{
			wording.Add("utterance"+x,utterance[x].Split(' ').ToList());
		}
	}
