    public void SomeMethod(int someInt)
    {
        if (someInt == 3)
            throw new ArgumentException("someInt must not be 3", "someInt");
        switch (someInt)
        {
            // ...
        }
    }
 
