            [Test]
            public void DateTimeTest()
            {
                var dateTime = new DateTime(2012, 12, 12, 12, 12, 0);
                int intDateTime = Int32.Parse(dateTime.ToString("yymmddHHMM", CultureInfo.CurrentCulture));
                byte[] bytesDateTime = BitConverter.GetBytes(intDateTime);
                string base64 = Convert.ToBase64String(bytesDateTime);
    
                Debug.WriteLine(base64);    // Prints fIA/SA==
    
                byte[] newBytesDateTime = Convert.FromBase64String(base64);
                int newIntDateTime = BitConverter.ToInt32(newBytesDateTime, 0);
                var newDateTime = DateTime.ParseExact(newIntDateTime.ToString(), "yymmddHHMM", CultureInfo.CurrentCulture);
    
                Assert.AreEqual( dateTime, newDateTime );
            }
