    [Test]
    public void CanUseRobots()
    {
      Robot robot1 = new Robot();
      Robot robot2 = new Robot();
      Robot robot3 = new Robot();
      Assert.AreEqual(0, robot1.ID);
      Assert.AreEqual(1, robot2.ID);
      Assert.AreEqual(2, robot3.ID);
      int expected = robot2.ID;
      robot2.Dispose();
      Robot robot4 = new Robot();
      Assert.AreEqual(expected, robot4.ID);
    }
