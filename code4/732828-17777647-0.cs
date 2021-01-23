    [Test]
    public void Test_XXXXXXX
    {
        var yourClass = new YourClass(); 
        Assert.That(()=>yourClass.Method(),
                        .Throws.Exception
                        .TypeOf<TypeOfYourException>
                        .With.Property("Message")
                        .EqualTo("the message you are expecting goes here")
                   );
    }
