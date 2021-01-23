    public void TestMethod()
        {
            //var c = new Fakes.Child();
            //c.addressGet = "foo"; // I can see that
            //c.NameGet = "bar"; // This DOES NOT exists
            using (ShimsContext.Create())
            {
                ShimChild childShim = null;
                ShimChild.Constructor = (@this) =>
                {
                    childShim = new ShimChild(@this);
                    // the below code now defines a ShimParent object which will be used by the ShimChild object I am creating here
                    new ShimParent()
                    {
                        NameSetString = (value) =>
                        {
                            //do stuff here
                        },
                        NameGet = () =>
                        {
                            return "name";
                        }
                    };
                };
            }
        }
