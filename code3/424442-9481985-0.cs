    [TestFixture]
	public class When_Scenario
	{
		[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.225")]
		[System.SerializableAttribute()]
		//[System.Diagnostics.DebuggerStepThroughAttribute()]
		[System.ComponentModel.DesignerCategoryAttribute("code")]
		[System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:core_e-nbp-v1.0")]
		public partial class ClaimApplication : object, System.ComponentModel.INotifyPropertyChanged
		{
			private System.DateTime hBEffectiveDateField;
			/// <remarks/>
			[System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 3)]
			public System.DateTime HBEffectiveDate
			{
				get
				{
					return this.hBEffectiveDateField;
				}
				set
				{
					this.hBEffectiveDateField = value;
				}
			}
			public event PropertyChangedEventHandler PropertyChanged;
		} 
		[Test]
		public void Should_Assertion()
		{
			ClaimApplication claimApplication = new ClaimApplication();
			claimApplication.HBEffectiveDate = DateTime.Now.ToUniversalTime();
			XmlSerializer s = new XmlSerializer(typeof(ClaimApplication));
			s.Serialize(Console.Out, claimApplication);
		}
	}
