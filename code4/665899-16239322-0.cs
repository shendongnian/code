    public void IsObjTypeOfSome_objectTest()
    {
        bool expected = true;
        bool actual = false;
        /* Assuming that test_function(obj) returns an object type of Some_object */
        if (test_function(obj) is Some_object)
        {
            actual = true;
        }
        Assert.AreEqual(expected, actual);
    }
