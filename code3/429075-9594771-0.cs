            byte[] verifyHex = new byte[] { 0x4F, 0x50,  0x54, 0x49, 0x4F, 0x4E, 0x53};
            byte[] verifyDec = new byte[] { 79, 80, 84, 73, 79, 78, 83};
            var message = Encoding.ASCII.GetBytes("OPTIONS");
            if (message.Where((t, i) => t != verifyDec[i] || t != verifyHex[i]).Any())
            {
                MessageBox.Show("Not equal.");
            }
            else
            {
                MessageBox.Show("All three representations are equal.");
            }
