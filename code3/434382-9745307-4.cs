    static class IFactoryProducing<ResultType>
    {
        interface WithParam<PT1>
        {
            ResultType Create(PT1 p1);
        }
        interface WithParam<PT1,PT2>
        {
            ResultType Create(PT1 p1, PT2 p2);
        }
    }
