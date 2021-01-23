    public interface IMyAggregateService
    {
      IFirstService FirstService { get; }
      ISecondService SecondService { get; }
      IThirdService ThirdService { get; }
      IFourthService FourthService { get; }
    }
