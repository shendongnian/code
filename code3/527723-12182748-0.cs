    class CheckNumbers
    {
        private const int DATE_INTERVAL = -7;
        private string _accountName;
        private DateTime _lastToDate;
        private DateTime _lastFromDate;
        public CheckNumbers(string accountName)
        {
            _accountName = accountName;
            _lastToDate = DateTime.Today;
            _lastFromDate = _lastToDate.AddDays(DATE_INTERVAL);
        }
        private void SetCriteria(IORTxnQuery qry)
        {
            qry.TxnFilter.AccountFilter.ORAccountFilter.FullNameList.Add(_accountName);
            var dateFilter = qry.TxnFilter.ORDateRangeFilter.ModifiedDateRangeFilter;
            dateFilter.FromModifiedDate.SetValue(_lastFromDate, true);
            dateFilter.ToModifiedDate.SetValue(_lastToDate, true);
        }
        private void ProcessCheckNumber(string checkNumber, ref int highestNumber)
        {
            if (!string.IsNullOrEmpty(checkNumber))
            {
                int thisCheck;
                if (!int.TryParse(checkNumber, out thisCheck))
                {
                    throw new Exception(string.Format("Check number {0} cannot be read as an integer", checkNumber));
                }
                if (thisCheck > highestNumber) highestNumber = thisCheck;
            }
        }
        public int GetLastCheckNumber()
        {
            DateTime failSafe = DateTime.Parse("1/1/2010");
            using (var cn = Zombie.ConnectionMgr.GetConnection())
            {
                int highestCheck = 0;
                while (highestCheck == 0 && _lastFromDate > failSafe)
                {
                    var batch = cn.NewBatch();
                    var checkQuery = batch.MsgSet.AppendCheckQueryRq();
                    checkQuery.IncludeRetElementList.Add("RefNumber");
                    SetCriteria(checkQuery.ORTxnQuery);
                    batch.SetClosures(checkQuery, b =>
                        {
                            var checks = new Zombie.QBFCIterator<ICheckRetList, ICheckRet>(b);
                            foreach (var check in checks)
                            {
                                ProcessCheckNumber(Zombie.Safe.Value(check.RefNumber), ref highestCheck);
                            }
                        });
                    var billCheckQuery = batch.MsgSet.AppendBillPaymentCheckQueryRq();
                    billCheckQuery.IncludeRetElementList.Add("RefNumber");
                    SetCriteria(billCheckQuery.ORTxnQuery);
                    batch.SetClosures(billCheckQuery, b =>
                        {
                            var checks = new Zombie.QBFCIterator<IBillPaymentCheckRetList, IBillPaymentCheckRet>(b);
                            foreach (var check in checks)
                            {
                                ProcessCheckNumber(Zombie.Safe.Value(check.RefNumber), ref highestCheck);
                            }
                        });
                    if (!batch.Run()) return 0;
                    _lastToDate = _lastFromDate;
                    _lastFromDate = _lastToDate.AddDays(DATE_INTERVAL);
                }
                return highestCheck;
            }
        }
    }
