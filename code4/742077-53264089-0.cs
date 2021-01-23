    public abstract class AbCommon
	{
		public virtual AbCommon Successor { get; protected set; }
		public virtual void Execute()
		{			
			if (Successor != null)
			{
				Successor.Execute();
			}
		}
		public virtual void SetSuccessor(AbCommon successor)
		{
			if (Successor != null)
			{
				Successor.SetSuccessor(successor);
			}
			else
			{
				this.Successor = successor;
			}
		}
	}
	class DefaultClass : AbCommon
	{	
		public override void Execute()
		{
			Console.WriteLine("DC");
			base.Execute();
		}		
	}
	class FirstClass: AbCommon
	{
		public override void Execute()
		{
			Console.WriteLine("FC");
			base.Execute();
		}
	}
	class SecondClass: AbCommon
	{	
		public override void Execute()
		{
			Console.WriteLine("SC");
			base.Execute();
		}
	}
	class ThirdClass: AbCommon
	{
		public override void Execute()
		{
			Console.WriteLine("TC");
			base.Execute();
		}
	}
