	public class RandomStringOfLengthRequest
	{
		public RandomStringOfLengthRequest(int length) : this(length, "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz01234567890 !?,.-")
		{
		}
		public RandomStringOfLengthRequest(int length, string charactersToUse): this(length, charactersToUse, new Random())
		{
		}
		public RandomStringOfLengthRequest(int length, string charactersToUse, Random random)
		{
			Length = length;
			Random = random;
			CharactersToUse = charactersToUse;
		}
		public int Length { get; private set; }
		public Random Random { get; private set; }
		public string CharactersToUse { get; private set; }
		public string GetRandomChar()
		{
			return CharactersToUse[Random.Next(CharactersToUse.Length)].ToString();
		}
	}
	public class RandomStringOfLengthGenerator : ISpecimenBuilder
	{
		public object Create(object request, ISpecimenContext context)
		{
			if (request == null)
				return new NoSpecimen();
			var stringOfLengthRequest = request as RandomStringOfLengthRequest;
			if (stringOfLengthRequest == null)
				return new NoSpecimen();
			var sb = new StringBuilder();
			for (var i = 0; i < stringOfLengthRequest.Length; i++)
				sb.Append(stringOfLengthRequest.GetRandomChar());
			return sb.ToString();
		}
	}
