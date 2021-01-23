        private void GS1DataConvert(string pBarcode)
        {
            String aiFull = "";
            String aiWCheckSum = "";
            String aiValue = "";
            Int32 aiCheckSum = 0;
            Int32 aiMinLength = 0;
            Int32 aiMaxLength = 0;
            int index = 0;
            if (pBarcode.Contains("01"))
            {
                index = pBarcode.IndexOf("01") + 2;
                AII sai = getAiInfo("01");
                aiMinLength = sai.minLength;
                aiMaxLength = sai.maxLength;
                aiFull = pBarcode.Substring(index - 2, aiMaxLength + 2);
                aiWCheckSum = pBarcode.Substring(index, aiMaxLength);
                aiValue = aiWCheckSum.Remove(aiWCheckSum.Length - 1, 1);
                aiCheckSum = Int32.Parse(aiWCheckSum.Substring(aiWCheckSum.Length - 1, 1));
                if (checkSum(aiValue, aiCheckSum))
                {
                    pBarcode = pBarcode.Replace(aiFull, String.Empty);
                    textBox2.Text = aiValue;
                }
            }
            if (pBarcode.Contains("17"))
            {
                index = pBarcode.IndexOf("17") + 2;
                AII sai = getAiInfo("17");
                aiFull = pBarcode.Substring(index-2, sai.minLength+2);
                aiValue = pBarcode.Substring(index, sai.minLength);
                if (checkDate(aiValue)>DateTime.MinValue)
                {
                    pBarcode = pBarcode.Replace(aiFull, String.Empty);
                    textBox3.Text = aiValue;
                }
            }
            if(pBarcode.Contains("10"))
            {
                index = pBarcode.IndexOf("10") + 2;
                AII sai = getAiInfo("10");
                aiMinLength = sai.minLength;
                aiMaxLength = pBarcode.Length<sai.maxLength ? pBarcode.Length-2 : sai.maxLength;
                aiFull = pBarcode.Substring(index - 2, aiMaxLength + 2);
                aiValue = pBarcode.Substring(index, aiMaxLength);
                textBox4.Text = aiValue;
            }
        }
        private Boolean  checkSum (String pgtin,Int32 pchecksum)
        {
            Boolean ret = false;
            Int32 glength = 0;
            Int32 total = 0;
            Int32 cSum = 0;
            Int32[] mutiply = { 3, 1, 3, 1, 3, 1, 3, 1, 3, 1, 3, 1, 3, 1, 3, 1, 3 };
            glength = 17 - pgtin.Length;
            for (int i = 0; i < pgtin.Length; i++)
            {
                total = total + (Int32.Parse(pgtin[i].ToString()) * mutiply[i + glength]);
            }
            cSum = 10 - (total % 10);
            if (cSum == pchecksum)
            {
                ret = true;
            }
            return ret;
        }
        private DateTime checkDate(string pdate)
        {
            DateTime ret = DateTime.MinValue;
            DateTime convertedDate = DateTime.MinValue;
            String dFormat = "yyMMdd";
            if (DateTime.TryParseExact(pdate, dFormat, CultureInfo.CurrentCulture, DateTimeStyles.None, out convertedDate))
            {
                ret = convertedDate;
            }
            return ret;
        }
        public AII getAiInfo(String pAi)
        {
            AII naii = new AII();
            if (pAi=="01")
            {
                naii.AICode = "01";
                naii.minLength = 8;
                naii.maxLength = 14;
                return naii;
            }
            if (pAi == "17")
            {
                naii.AICode = "17";
                naii.minLength = 6;
                naii.minLength = 6;
                return naii;
            }
            if (pAi == "10")
            {
                naii.AICode = "10";
                naii.minLength = 1;
                naii.maxLength = 20;
            }
            return naii;
        }
        public struct AII
        {
            public String AICode;
            public Int32 minLength;
            public Int32 maxLength;
        }
