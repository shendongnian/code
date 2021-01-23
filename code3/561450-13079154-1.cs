    //project: Xarian.Security
    //file: Decrypt.cs
    namespace Xarian.Security
    {
        class Decrypt : Cipher
        {
            public string Execute()
            {
                //Code here
            }
        }
    }
.
    //project: Xarian.Security.Test
    //file: DecryptTest.cs
    using System;
    using NUnit.Framework;
    //as we're already in the Xarian.Security namespace, no need 
    //to reference it in code.  However the DLL needs to be referenced 
    //(Solution Explorer, Xarian.Security.Test, References, right click, 
    //Add Reference, Projects, Xarian.Security)
    namespace Xarian.Security
    {
        [TestFixture]
        class DecryptTest
        {
            [Test]
            public void test()
            {
                //Code here
                Cipher cipher = new Decrypt("&^%&^&*&*()%%&**&&^%$^&$%^*^%&*(");
                string result = cipher.Execute();
                Assert.AreEqual(string, "I'm Decrypted Successfully");
            }
        }
    }
