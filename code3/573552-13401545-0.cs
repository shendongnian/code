    public class BridgePolicy
	{
		public string Name { get; set; }
	}
	public class PolicyImage
	{
		public string Name { get; set; }
	}
	public interface IPolicyObjectAdapter
	{
		PolicyImage GetPolicyImage(BridgePolicy policy);
	}
	public class BridgePolicyAdapter : IPolicyObjectAdapter
	{
		protected virtual void AddPolicyInformation(BridgePolicy policy)
		{
			//does stuff
		}
		public virtual PolicyImage GetPolicyImage(BridgePolicy policy)
		{
			AddPolicyInformation(policy);
			return null;
		}
	}
	public class HSPolicyAdapter : BridgePolicyAdapter, IPolicyObjectAdapter
	{
		protected override void AddPolicyInformation(BridgePolicy policy)
		{
			base.AddPolicyInformation(policy);
			//does more stuff
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			BridgePolicy p = new BridgePolicy();
			IPolicyObjectAdapter Adapter = null;
			Adapter = new HSPolicyAdapter();
			PolicyImage image = Adapter.GetPolicyImage(p);
		}
	}
