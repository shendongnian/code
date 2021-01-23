    [TestMethod]
    public void AppraisalOrderIsAcceptedByEmployee_Should_Redirect_To_VerifyOrderDetails_Action_If_SubmitAppraisalOrder_Throws_A_MessageLoneException()
    {
        // arrange
        var appraisalOrderId = 5;
        var orderServiceMock = MockRepository.GenerateMock<IOrderService>();
        orderServiceMock
            .Expect(x => x.SubmitAppraisalOrder(appraisalOrderId))
            .Throw(new MessageLoneException());
        var sut = new MyController(orderServiceMock);
    
        // act
        var actual = sut.AppraisalOrderIsAcceptedByEmployee(appraisalOrderId);
    
        // assert
        Assert.IsInstanceOfType(actual, typeof(RedirectToRouteResult));
        Assert.AreEqual("VerifyOrderDetails", result.RouteValues["action"]);
        Assert.AreEqual(appraisalOrderId, result.RouteValues["id"]);
    }
