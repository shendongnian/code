		[Test]
		public void CheckId ()
		{
			Guid g = Guid.NewGuid ();
			SetID (g);
			Assert.That (g, Is.EqualTo (GetID ()), "same guid");
		}
