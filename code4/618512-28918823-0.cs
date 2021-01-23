    Assert.IsNotNull(result, "result");
    Assert.IsNotNull(result.VersionData, "Version data");
    CollectionAssert.IsNotEmpty(result.VersionData)
    var adjustmentAccountsInfoData = result.VersionData[0].AdjustmentAccountsInfo;
    Assert.IsFalse(adjustmentAccountsInfoData.IsContractAssociatedWithAScheme);
    Assert.AreEqual(RiskGroupStatus.High, adjustmentAccountsInfoData.Status);
    Assert.That(adjustmentAccountsInfoData.RiskGroupModel, Is.EqualTo(RiskGroupModel.Flexible));
    Assert.AreEqual("b", adjustmentAccountsInfoData.PriceModel);
    Assert.IsTrue(adjustmentAccountsInfoData.IsManual);
