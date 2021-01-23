    class NumericValue : ITimedValue<float> {
     public TimeSpan TimeStamp { get; private set; }
     public float Value { get; private set; }
    }
    
    class DateTimeValue : ITimedValue<DateTime>, ITimedValue<float> {
     public TimeSpan TimeStamp { get; private set; }
     public DateTime Value { get; private set; }
     public Float ITimedValue<Float>.Value { get { return 0; } }
    }
    
    class NumericEvaluator {
     public void Evaluate(IEnumerable<ITimedValue<float>> values) ...
    }
