    interface IJobFactory
    {
      IJob Create();
    }
    
    class FullTimeJobFactory
      : IJobFactory
    {
      IJob Create()
      {
        return new FullTimeJob();
      }
    }
    
    class InternshipJobFactory
      : IJobFactory
    {
      IJob Create()
      {
        return new InternshipJob();
      }
    }
