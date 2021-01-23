    // 1
    Assert.IsTrue(firstRow.Text != null && firstRow.Text.Contains("SomeText"));
    // 2
    Assert.IsNotNull(firstRow.Text);
    Assert.IsTrue(firstRow.Text.Contains("SomeText"));
    // 3
    var text = firstRow.Text;
    Assert.IsTrue(text != null && text.Contains("SomeText"));
