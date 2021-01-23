	public abstract class BankAccount
	{
		private DateTime _creationDate = DateTime.Now;
		public DateTime CreationDate
		{
			get { return _creationDate; }
			set { _creationDate = value; }
		}
		public virtual string CreationDateUniversal
		{
			get { return _creationDate.ToUniversalTime().ToString(); }
		}
	}
	public class SavingAccount : BankAccount
	{
		public override string CreationDateUniversal
		{
			get
			{
				return base.CreationDateUniversal + " UTC";
			}
		}
	}
