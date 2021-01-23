    static class IFactoryProducing&lt;ResultType>
    {
        interface WithParam&lt;PT1>
        {
            ResultType Create(PT1 p1);
        }
        interface WithParam&lt;PT1,PT2>
        {
            ResultType Create(PT1 p1, PT2 p2);
        }
    }
