	public class BirdCall : fitlibrary.SetUpFixture
	{
		public void BirdNameNoise(string birdName, string noise)
		{
			BirdName = birdName;
			Noise = noise;
		}
		public string BirdName;	
		public string Noise;
		public override string ToString()
		{
			return string.Format("BirdCall: {0}, {1}", BirdName, Noise);
		}
	}
	public class SkylarkBunting : fitlibrary.DoFixture
	{
		public BirdCall BirdCall;
		public string Call;
		public Fixture CryOut()
		{
			BirdCall = new BirdCall();
			Call = BirdCall.Noise;
			return BirdCall;
		}
		public string GetCall()
		{
			return BirdCall.Noise;
		}
		public string GetName()
		{
			return BirdCall.BirdName;
		}
	}
