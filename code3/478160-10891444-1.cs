	public class Options {
		public virtual int Option { get; set; }
		public virtual int Value { get; set; }
	}
	public class Document {
		public virtual int ID { get; set; }
		public virtual String Name { get; set; }
		public virtual IList<DocumentOption> DocumentOptions { get; set; }
	}
