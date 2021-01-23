    [TestMethod]
    public void AreFlagsDeniedAndAcknowledged()
    {
        Assert.AreEqual(ApprovalItemState.DenialAcknowledged, ApprovalItemState.Denied | ApprovalItemState.Acknowledged);
    }
