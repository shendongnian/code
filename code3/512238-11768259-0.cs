    !|BirdCall|
    |birdName|noise|
    |duck|quack|
    public class SkylarkBunting : fitlibrary.DoFixture
    {
        public BirdCall BirdCall;
        public SkylarkBunting(BirdCall birdCall)
        {
            BirdCall = birdCall;
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
