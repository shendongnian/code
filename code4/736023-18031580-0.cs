        private DialedNumber applyCallPattern(string noToDial)
        {
            noToDial = noToDial.Replace("callto:", ""); 
           //libphone removes text anyway so this line above is not needed
            PhoneNumberUtil phoneUtil = PhoneNumberUtil.GetInstance();
            string dc = "SG";
            if (AutoDialer.Properties.Settings.Default.BaseOffice == "Hong Kong")
            {
                dc = "HK";
            }
            PhoneNumber pn = phoneUtil.Parse(noToDial, dc);
            string rc = phoneUtil.GetRegionCodeForNumber(pn);
            string dialingNumber = null;
            if (rc == "SG")
            {
                dialingNumber = phoneUtil.Format(pn, PhoneNumberFormat.NATIONAL);
                if (AutoDialer.Properties.Settings.Default.BaseOffice == "Hong Kong")
                {
                    dialingNumber = "*65" + dialingNumber;
                }
            }
            else if (rc == "HK")
            {
                dialingNumber = phoneUtil.Format(pn, PhoneNumberFormat.NATIONAL);
                if (AutoDialer.Properties.Settings.Default.BaseOffice == "Singapore")
                {
                    dialingNumber = "*852" + dialingNumber;
                }
            }
            else
            {
                dialingNumber = phoneUtil.Format(pn, PhoneNumberFormat.E164);
                dialingNumber = dialingNumber.Replace("+", "001");
            }
            dialingNumber = dialingNumber.Replace(" ", "");
            DialPopup popup = new DialPopup();
            popup.label1.Text = "Calling: " + dialingNumber;
            popup.Show();
            DialedNumber dn = new DialedNumber(dialingNumber, phoneUtil.GetRegionCodeForNumber(pn), phoneUtil.GetNumberType(pn).ToString(), DateTime.Now, false);
            Program.lastNoDialed = dialingNumber;
            return dn;
        }
