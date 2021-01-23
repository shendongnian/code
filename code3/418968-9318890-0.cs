      [TestMethod]
      public void AddSomeElements_Adds_The_Specified_Number_Of_Elements 
      {
         //Arrange
         var elementList = new List<int>();
         elementList.Add(1);
         elementList.Add(2);
         elementList.Add(3);
         int expected = 6;
         //Act
         AddSomeElements(elementList, 3);
         int actual = elementList.Count;
         //Assert
         Assert.AreEqual(expected, actual);
      }
