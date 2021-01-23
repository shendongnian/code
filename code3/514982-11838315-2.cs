        namespace ActiveXTest
        {
            [System.Runtime.InteropServices.ComVisible(true)]
            [System.Runtime.InteropServices.ProgId("ActiveXTest.MyObject")]
            [System.Runtime.InteropServices.Guid("df2dac4d-ba8a-4ecc-b76e-958c1bc32f1f")]
            public class MyObject
            {
                public string HelloWorld()
                {
                    return "This is Hello World from the COM component!";
                }
            }
        }
