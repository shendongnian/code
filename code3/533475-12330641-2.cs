      [Test]
      public void ValidateGoodEmail()
      {
         Validator validator = new Validator();
         bool shouldBeTrue = validator.ValidateEmail("test@test.com");
      
         Assert.AreEqual(true, shouldBeTrue);
      }
      [Test]
      public void ValidateBadEmail()
      {
         Validator validator = new Validator();
         bool shouldBeFalse = validator.ValidateEmail("test@.com");
      
         Assert.AreEqual(false, shouldBeFalse);
      }
