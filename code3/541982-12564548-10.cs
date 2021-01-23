    public class MvxPhoneCallTask : MvxWindowsPhoneTask, IMvxPhoneCallTask
    {
        #region IMvxPhoneCallTask Members    
    
        public void MakePhoneCall(string name, string number)
        {
            var pct = new PhoneCallTask {DisplayName = name, PhoneNumber = number};
            DoWithInvalidOperationProtection(pct.Show);
        }
        #endregion
    }
