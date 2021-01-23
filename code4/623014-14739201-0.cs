    interface IInfo<T>
    {
        T Max { get; set; }
        T Min { get; set; }
        T DefaultValue { get; set; }
        T Step { get; set; }
    }
    Dictionary<string, IInfo> dict = new Dictionary<string, IInfo>();
    class AnswerInfo : IInfo<bool> { }
    class PriceInfo : IInfo<int> { }
    class AdvInfo : IInfo<double> { }
    dict["Answer"] = new AnswerInfo() { Min = false, Max = false, DefaultValue = false, Step = false };
    dict["Price"] = new PriceInfo() { Min = 100, Max = 1000, DefaultValue = 200, Step = 50 };
    dict["Adv"] = new AdvInfo() { Min = 10.50, Max = 500.50, DefaultValue = 20.50 Step = 1.5 };
