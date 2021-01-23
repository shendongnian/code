    [TestMethod]
        public void Test_GetProperty_ForValidTypeAndKey_ReturnsValue()
        {
            // Arrange
            String luaScript = MockLuaScripts.TEST_OBJECT_WITH_STRING;
            Script context = new Script();
            String expectedResult = MockLuaScripts.ValidValue1;
            // Act
            /* Run the script */
            context.DoString(luaScript);
            /* Get the object */
            DynValue resultObject = context.Globals.Get(MockLuaScripts.ObjectInstance1);
            /* Get the property */
            DynValue tableValue = instance.Table.Get((MockLuaScripts.ValidKey1);
            String actualResult = tableValue.String();
            /* Or you can use..
                String actualResult = tableValue.ToObject<String>();
            */
            
            // Assert 
            Assert.AreEqual(expectedResult, actualResult);
        }
