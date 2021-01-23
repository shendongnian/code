    public class TestableEntity : Entity
    {
        internal int PublishReturnValue { get; set; }
        public override int Publish(int value)
        {
            return PublishReturnValue;
        }
    }
