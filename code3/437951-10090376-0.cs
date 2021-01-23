     public bool ValidDate(string pTextDate, out DateTime? pDate, out string errorMessage)
        {
            DateTime tempDate;
            errorMessage = "";
            pDate = null;
            if (pTextDate.Length == 0)
            {
                //pass null date here...
                return true;
            }
            DateTime.TryParse(pTextDate, out tempDate);
            if (tempDate == DateTime.MinValue)
            {
                errorMessage = "date must be in format MM/dd/yyyy";
                return false;
            }
            pDate = tempDate;
            return true;
        }
        private void txtDueDateDetail_Leave(object sender, EventArgs e)
        {
            string errorMsg;
            DateTime? outDate;
            if (!ValidDate(txtDueDateDetail.Text, out outDate, out errorMsg))
            {
                txtDueDateDetail.Select(0, txtDueDateDetail.Text.Length);
            }
            else
            {
                int CID = Convert.ToInt32(txtChargebackIDDetail.Text);
                var temp = (from c in chg.ChargeBackks
                            where c.ID == CID
                            select c).FirstOrDefault();
                temp.DueDate = outDate;
            }
            this.epNew.SetError(txtDueDateDetail, errorMsg);
        }
