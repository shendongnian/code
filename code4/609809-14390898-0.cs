    private void button2_Click(object sender, EventArgs e)
        {
            Embed();
        }
    public void Embed(string Embedkey, string EmbedMessage,Bitmap image3)
        {
         // embed message in image
        }
   
    public void EmbedTest()
        {
            StegApp target = new StegApp(); // TODO: Initialize to an appropriate value
            string Embedkey = "123456"; // TODO: Initialize to an appropriate value
            string EmbedMessage = "test2"; // TODO: Initialize to an appropriate value
            Bitmap image3 = null; // TODO: Initialize to an appropriate value
            image3 = new Bitmap(@"C:\Users\Admin\Documents\dt265\Project\Sky\sky-and-cloud.bmp",true);
            string a="123456",b="test2";
            target.Embed(Embedkey, EmbedMessage, image3);
            //Assert.Inconclusive("A method that does not return a value cannot be verified.");
            if (Embedkey.Length > 6 || Embedkey.Length < 0)
            {
                Assert.Fail("Key is out of range");
            }
            //Assert.IsInstanceOfType(target.b1,typeof(byte[]));
            if(target.b1.Length != target.temp4.Length)
            {
                Assert.Fail("B1 array does not have the correct lenght");
            }
            Assert.IsInstanceOfType(target.image1,typeof(Bitmap));
            Assert.IsInstanceOfType(target.sb,typeof(StringBuilder));
            if(target.sb.Length != target.tmp3.Length)
            {
                Assert.Fail("Issue with Stringbuilder sb. Lenght not equal to 'tmp3'!");
            }
            if(target.z != target.StringLenght)
            {
                Assert.Fail("z != StringLenght");
            }
            if (target.c != EmbedMessage.Length)
            {
                Assert.Fail("c is not the lenght of the Message!");
            }
            
        }
            
