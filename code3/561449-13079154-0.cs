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
    //as we're already in the Xarian.Security namespace, no need to reference it in code.
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
