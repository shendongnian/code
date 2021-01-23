    partial class Process : IComparable<Process>
    {
      public override int CompareTo(Process otherProcess) 
      {
        if (this.arrivalTime == otherProcess.arrivalTime)
          return this.brust.CompareTo(otherProcess.brust);
        return this.arrivalTime.CompareTo(otherProcess.brust);
      }
    }
